using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class ObjectPlacer : MonoBehaviour
{
    public GameObject objectToPlace; // Kéo prefab vào đây trong inspector
    public Camera mainCamera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Nhấn chuột trái để đặt vật thể
        {
            PlaceObject();
        }
    }

    void PlaceObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Kiểm tra va chạm với mặt đất
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 spawnPosition = hit.point; // Vị trí va chạm
            Instantiate(objectToPlace, spawnPosition, Quaternion.identity);
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}