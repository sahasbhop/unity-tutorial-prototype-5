using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private const float ForceMin = 10;
    private const float ForceMax = 15;
    private const float TorqueRange = 10;
    private const float ScreenWidthRange = 4;
    private const float SpawnPositionY = -1;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(ForceVector(), ForceMode.Impulse);
        _rigidbody.AddTorque(TorqueVector(), ForceMode.Impulse);
        transform.position = SpawnPosition();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private static Vector3 ForceVector()
    {
        return Vector3.up * Random.Range(ForceMin, ForceMax);
    }
    
    private static Vector3 TorqueVector()
    {
        return new Vector3(RandomSymRange(TorqueRange), RandomSymRange(TorqueRange), RandomSymRange(TorqueRange));
    }

    private static Vector3 SpawnPosition()
    {
        return new Vector3(RandomSymRange(ScreenWidthRange), SpawnPositionY);
    }

    private static float RandomSymRange(float value)
    {
        return Random.Range(-value, value);
    }
}