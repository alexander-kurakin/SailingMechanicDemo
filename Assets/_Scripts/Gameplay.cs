using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private float _windPower = 15f;
    [SerializeField] private float _windChangeInterval = 30f;

    [SerializeField] private float _minXborder = -500f;
    [SerializeField] private float _maxXborder = 0f;
    [SerializeField] private float _minZborder = 0f;
    [SerializeField] private float _maxZborder = 500f;

    [SerializeField] private WindVisual _windVisual;
    [SerializeField] private Boat _boat;
    [SerializeField] private Vector3 _centerOfTheWaterPlane;

    private Wind _wind;

    private void Awake()
    {
        _wind = new Wind(_windPower, _centerOfTheWaterPlane, _windChangeInterval, _minXborder, _maxXborder, _minZborder, _maxZborder);
        _wind.Initialize();

        _windVisual.Initialize(_wind);
        _boat.Initialize(_wind);
    }

    private void Update()
    {
        _wind.Update();
    }
}
