using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject mousePointer;
    [SerializeField] private GameObject gridIndicator;
    [SerializeField] private Grid grid;

    void Update()
    {
        Vector3 mousePos = inputManager.GetSelectedPosition();
        mousePointer.transform.position = mousePos;
        
        Vector3Int cellPos = grid.WorldToCell(mousePos);
        gridIndicator.transform.position = grid.CellToWorld(cellPos);
    }
}
