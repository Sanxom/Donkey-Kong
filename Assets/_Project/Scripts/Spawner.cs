using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnerPrefab;
    public float minTime = 2;
    public float maxTime = 4;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(spawnerPrefab, transform.position, Quaternion.identity);
        Invoke(nameof(Spawn), Random.Range(minTime, maxTime));
    }
}