using UnityEngine;

public class Wind
{
    private Vector3 _windDirection;
    private float _windSpeed;
    private float _randomChangeInterval;
    private Vector3 _centerOfTheWaterPlane;

    private float _randomChangeTimer = 0f;
    private float _minXBoarder = -500f;
    private float _maxXBoarder = 0f;
    private float _minZBoarder = 0f;
    private float _maxZBoarder = 500f;

    public Wind(float windSpeed, Vector3 centerOfTheWaterPlane, float randomChangeInterval)
    {
        _windSpeed = windSpeed;
        _centerOfTheWaterPlane = centerOfTheWaterPlane;
        _randomChangeInterval = randomChangeInterval;
    }

    public void Initialize()
    {
        _randomChangeTimer = _randomChangeInterval;
        ChangeWindDirectionRandomly();
    }

    public void Update()
    { 
        _randomChangeTimer -= Time.deltaTime;

        if (_randomChangeTimer <= 0f)
        {
            ChangeWindDirectionRandomly();
            _randomChangeTimer = _randomChangeInterval;
        }
    }

    private void ChangeWindDirectionRandomly()
    {
        _windDirection = new Vector3(
            UnityEngine.Random.Range(_minXBoarder, _maxXBoarder), 
            0,
            UnityEngine.Random.Range(_minZBoarder, _maxZBoarder)
            );
    }

    public Vector3 GetWindDirection()
    {
        return (_windDirection - _centerOfTheWaterPlane).normalized;
    }

    public float GetWindSpeed()
    {
        return _windSpeed;
    }
}
