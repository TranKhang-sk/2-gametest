using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject soldierPrefab; // Kéo prefab của lính vào đây trong inspector
    public float spawnInterval = 2.0f; // Thời gian giữa các lần spawn
    private bool isSpawning = false;

    void Start()
    {
        // Bắt đầu spawn lính sau một khoảng thời gian
        InvokeRepeating("SpawnSoldier", spawnInterval, spawnInterval);
    }

    void SpawnSoldier()
    {
        if (isSpawning)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            Instantiate(soldierPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void StartSpawning()
    {
        isSpawning = true;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}