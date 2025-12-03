using UnityEngine;

public class Wind
{
    private Vector3 _windDirection;
    private float _windSpeed;
    private float _randomChangeInterval;
    private Vector3 _centerOfTheWaterPlane;

    private float _randomChangeTimer = 0f;
    private float _minXBoarder;
    private float _maxXBoarder;
    private float _minZBoarder;
    private float _maxZBoarder;

    public Wind(float windSpeed, Vector3 centerOfTheWaterPlane, float randomChangeInterval, float minXBorder, float maxXBorder, float minZBoarder, float maxZBoarder)
    {
        _windSpeed = windSpeed;
        _centerOfTheWaterPlane = centerOfTheWaterPlane;
        _randomChangeInterval = randomChangeInterval;
        _minXBoarder = minXBorder;
        _maxXBoarder = maxXBorder;
        _minZBoarder = minZBoarder;
        _maxZBoarder= maxZBoarder;
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
            Random.Range(_minXBoarder, _maxXBoarder), 
            0,
            Random.Range(_minZBoarder, _maxZBoarder)
            );
    }

    public Vector3 GetNormalizedWindDirection()
    {
        return (_windDirection - _centerOfTheWaterPlane).normalized;
    }

    public float GetWindSpeed()
    {
        return _windSpeed;
    }
}
