using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] LayerMask placementLayerMask;
    private Vector3 lastPosition;
    public event Action onClicked, onExit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) onClicked?.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape)) onExit?.Invoke();
    }

  public bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();
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
