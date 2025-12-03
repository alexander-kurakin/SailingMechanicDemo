using UnityEngine;

public class WindVisual : MonoBehaviour
{
    [SerializeField] private GameObject _arrowObject;
    [SerializeField] private GameObject _boatObject;

    private Wind _wind;

    public void Initialize(Wind wind)
    {
        _wind = wind;
    }

    private void Update()
    {
        _arrowObject.transform.rotation = Quaternion.FromToRotation(_arrowObject.transform.up, _wind.GetNormalizedWindDirection()) * _arrowObject.transform.rotation;
        _arrowObject.transform.position = _boatObject.transform.position + new Vector3(2f, 1.5f, 0);
    }
}
