using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private float _windPower;
    [SerializeField] private float _windChangeInterval;

    [SerializeField] private WindVisual _windVisual;
    [SerializeField] private Boat _boat;
    [SerializeField] private Vector3 _centerOfTheWaterPlane;

    private Wind _wind;

    private void Awake()
    {
        _wind = new Wind(_windPower, _centerOfTheWaterPlane, _windChangeInterval);
        _wind.Initialize();

        _windVisual.Initialize(_wind);
        _boat.Initialize(_wind);
    }

    private void Update()
    {
        _wind.Update();
    }
}
