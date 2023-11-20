using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] targets;
    private const float SpawnRate = 1.0f;

    private void Start()
    {
        StartCoroutine(SpawnTargetRoutine());
    }

    private IEnumerator SpawnTargetRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
            Instantiate(targets[Random.Range(0, targets.Length)]);
        }
    }
}