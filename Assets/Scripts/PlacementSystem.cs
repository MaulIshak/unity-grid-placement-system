using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject mousePointer;
    [SerializeField] private GameObject gridIndicator;
    [SerializeField] private Grid grid;
    [SerializeField] private ObjectsDatabaseSO database;
    [SerializeField] private GameObject gridVisualization;
    private int selectedObjectIndex = -1;

    private void Start()
    {
        StopPlacement();
    }
    public void StartPlacement(int ID)
    {
        StopPlacement();
        selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        if (selectedObjectIndex < 0)
        {
            Debug.LogError($"No ID {ID} founded");
            return;
        }

        gridIndicator.SetActive(true);
        gridVisualization.SetActive(true);
        inputManager.onClicked += PlaceStructure;
        inputManager.onExit += StopPlacement;

    }

    private void PlaceStructure()
    {
        if (inputManager.IsPointerOverUI()) return;
        Vector3 mousePos = inputManager.GetSelectedPosition();
        Vector3Int cellPos = grid.WorldToCell(mousePos);
        GameObject newObject = Instantiate(database.objectsData[selectedObjectIndex].Prefab);
        newObject.transform.position = grid.CellToWorld(cellPos);
    }

    private void StopPlacement()
    {
        selectedObjectIndex = -1;
        gridIndicator.SetActive(false);
        gridVisualization.SetActive(false);
        inputManager.onClicked -= PlaceStructure;
        inputManager.onExit -= StopPlacement;

    }
    void Update()
    {
        Vector3 mousePos = inputManager.GetSelectedPosition();
        mousePointer.transform.position = mousePos;
        
        Vector3Int cellPos = grid.WorldToCell(mousePos);
        gridIndicator.transform.position = grid.CellToWorld(cellPos);
    }
}
