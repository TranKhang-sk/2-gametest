using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Kéo thả prefab vào đây trong inspector
    public Transform spawnArea; // Kéo thả khu vực spawn vào đây trong inspector
    public float spawnInterval = 2.0f; // Khoảng cách giữa các lần spawn

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // Kiểm tra xem đã đến lúc spawn chưa
        if (Time.time > nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObject()
    {
        // Tạo một vị trí ngẫu nhiên trong khu vực spawn
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
            spawnArea.position.y,
            Random.Range(spawnArea.position.z - spawnArea.localScale.z / 2, spawnArea.position.z + spawnArea.localScale.z / 2)
        );

        // Tạo đối tượng
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}