using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    public ParticleSystem explosionParticle;

    private Rigidbody _rigidbody;
    private GameManager _gameManager;
    private const float ForceMin = 10;
    private const float ForceMax = 15;
    private const float TorqueRange = 10;
    private const float ScreenWidthRange = 4;
    private const float SpawnPositionY = -1;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _rigidbody.AddForce(ForceVector(), ForceMode.Impulse);
        _rigidbody.AddTorque(TorqueVector(), ForceMode.Impulse);
        transform.position = SpawnPosition();
    }

    private void OnMouseDown()
    {
        if (!_gameManager.IsGameActive()) return;

        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);
        _gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
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