using System;
using UnityEngine;

public class SoilScript : MonoBehaviour
{
    // Define the properties that determine if a crop can be planted
    public GameObject[] fertilityStages; // Array of growth stage models
    public bool canPlant = true;                    // Whether the player can plant on this terrain 
    private GridManager gridManager;

    private void Start()
    {
        TimeManager timeManager = FindObjectOfType<TimeManager>();
        gridManager = FindObjectOfType<GridManager>();
        timeManager.OnNextDay.AddListener(AdvanceFertility);
    }

    // This function checks if the conditions are right for planting a crop
    /*public bool CanPlayerPlant()
    {
        return canPlant;
    }*/

    // Advance Growth runs every time a day is passed. The lines of code withing AdvanceGrowth() will determine
    // if the plant gets to advance or be stagnant in growth.
    public void AdvanceFertility()
    {
        // Condition 1: Water level
        // If conditions 1 and 2 are met, then below line may run
        // f0.f add more conditions for this line to be able to run (check sunlight and water)
        Tile tile = gridManager.GetTileAt(transform.position);
        for (int i = 0; i < fertilityStages.Length; i++)
        {
            fertilityStages[i].SetActive(i == tile.WaterLevel);
        }
    }
}