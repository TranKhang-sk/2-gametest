using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public GameObject buildingPrefab; // Kéo prefab của tòa nhà vào đây trong inspector
    public Camera mainCamera;
    public LayerMask placementLayer; // Layer để kiểm tra vị trí đặt
    private GameObject currentBuilding; // Đối tượng tòa nhà hiện tại
    private GameObject shadow; // Đối tượng bóng


    void Update()
    {
        if (currentBuilding != null)
        {
            MoveBuilding();
            if (Input.GetMouseButtonDown(0)) // Nhấn chuột trái để đặt tòa nhà
            {
                PlaceBuilding();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) // Nhấn chuột trái để bắt đầu đặt tòa nhà
            {
                StartPlacing();
            }
        }
    }

    void StartPlacing()
    {
        currentBuilding = Instantiate(buildingPrefab); // Tạo tòa nhà mới
        shadow = Instantiate(shadowPrefab); // Tạo bóng
        shadow.SetActive(true); // Bật bóng
    }

    void MoveBuilding()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Kiểm tra va chạm với mặt đất
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, placementLayer))
        {
            Vector3 spawnPosition = hit.point; // Vị trí va chạm
            currentBuilding.transform.position = spawnPosition; // Di chuyển tòa nhà đến vị trí
            shadow.transform.position = spawnPosition; // Di chuyển bóng đến vị trí
            shadow.transform.rotation = Quaternion.Euler(90, 0, 0); // Đặt góc quay cho bóng
        }
    }

    void PlaceBuilding()
    {
        // Kiểm tra nếu tòa nhà có thể được đặt
        if (currentBuilding != null)
        {
            Building building = currentBuilding.GetComponent<Building>();
            if (building != null)
            {
                building.StartSpawning(); // Bắt đầu spawn lính
            }
            currentBuilding = null; // Đặt tòa nhà xong, reset
        }
    }
}