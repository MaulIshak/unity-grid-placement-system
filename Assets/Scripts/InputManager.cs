using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] LayerMask placementLayerMask;
    private Vector3 lastPosition;

    public Vector3 GetSelectedPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.nearClipPlane; // Menetapkan nilai z agar ray dimulai dari dekat kamera (near clip plane).
        Ray ray = mainCamera.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000, placementLayerMask))
        {
            lastPosition = hit.point;
        }

        return lastPosition;
    }

}
