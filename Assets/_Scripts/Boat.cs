using TMPro;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private Wind _wind;
    private Rigidbody _rigidbody;

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotationStep;
    [SerializeField] private float _leftSailAngle;
    [SerializeField] private float _rightSailAngle;

    [SerializeField] private Transform _sailTransform;
    [SerializeField] private Transform _sailRealDirectionTransform;
    [SerializeField] private TMP_Text _infoText;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Wind wind)
    {
        _wind = wind;
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        ProcessWindMovement();
    }

    private void ProcessWindMovement()
    {
        Vector3 boatDirection = transform.forward;
        Vector3 windDirection = _wind.GetWindDirection();
        Vector3 sailDirection = _sailRealDirectionTransform.forward;

        float sailEffect = Vector3.Dot(sailDirection, windDirection);
        sailEffect = Mathf.Clamp01(sailEffect);

        float forwardEffect = Vector3.Dot(windDirection, boatDirection);
        forwardEffect = Mathf.Clamp01(forwardEffect);

        float windPower = sailEffect * forwardEffect * _wind.GetWindSpeed();
        Vector3 boatSailingForce = boatDirection * windPower;

        _rigidbody.AddForce(boatSailingForce * Time.fixedDeltaTime, ForceMode.Force);

        _infoText.text = $"Note: Red=Boat, Green=Sail, Cyan=Wind\n" +
                         $"Numbers:\n" +
                         $"Sail component: {sailEffect:F2}\n" +
                         $"Forward component: {forwardEffect:F2}\n" +
                         $"Wind result speed: {windPower:F2}\n" +
                         $"Boat Position: {transform.position:F2}";

    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotateAroundAxis(transform.up, transform, _rotationSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotateAroundAxis(transform.up, transform, -_rotationSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            LocalRotateFixedAngles(_sailTransform, _leftSailAngle, _rotationStep);
        }

        if (Input.GetKey(KeyCode.E))
        {
            LocalRotateFixedAngles(_sailTransform, _rightSailAngle, _rotationStep);
        }
    }

    private void RotateAroundAxis(Vector3 axis, Transform transformToRotate, float rotateSpeed)
    {
        Quaternion yRotation = Quaternion.AngleAxis(rotateSpeed * Time.deltaTime, axis);
        transformToRotate.rotation = yRotation * transformToRotate.rotation;
    }

    private void LocalRotateFixedAngles(Transform transformToRotate, float maxAngle, float rotationStep) 
    {
        transformToRotate.localRotation = Quaternion.
            RotateTowards(transformToRotate.localRotation, Quaternion.Euler(0, maxAngle, 0),
            rotationStep * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 5f);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(_sailRealDirectionTransform.position, _sailRealDirectionTransform.forward * 2f);

        if (_wind == null)
            return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + _wind.GetWindDirection() * 5f);



    }
}
