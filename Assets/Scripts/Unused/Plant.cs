using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject[] growthStages; // Array of growth stage models
    public int currentStage = 0;      // Current growth stage
    public int daysPerStage = 2;      // Days required to move to the next stage
    public int minSun = 2;
    public int minWater = 2;
    private int daysGrowingSinceLastStage = 0;
    private int ageDays = 0;          // Keeps track of the age of a plant
    private GridManager gridManager;

    private void Start()
    {
        TimeManager timeManager = FindObjectOfType<TimeManager>();
        timeManager.OnNextDay.AddListener(AdvanceGrowth);
        gridManager = FindObjectOfType<GridManager>();
    }


    // Advance Growth runs every time a day is passed. The lines of code withing AdvanceGrowth() will determine
    // if the plant gets to advance or be stagnant in growth.
    public void AdvanceGrowth()
    {
        Tile tile = gridManager.GetTileAt(transform.position);
        ageDays++;

        if (ageDays == 1)
        {
            currentStage++;
            UpdateGrowthStage();
            return;
        }

        // Condition 1: Water level
        // Condition 2: Sun level
        // If conditions 1 and 2 are met, then below line may run
        daysGrowingSinceLastStage++; // f0.f add more conditions for this line to be able to run (check sunlight and water)
        bool tileCondMet = tile.WaterLevel >= minWater && tile.SunLevel >= minSun;

        if (daysGrowingSinceLastStage >= daysPerStage && currentStage < growthStages.Length - 1 && tileCondMet)
        {
            daysGrowingSinceLastStage = 0;
            currentStage++;
            UpdateGrowthStage();
        }
    }

    private void UpdateGrowthStage()
    {
        // Activate the current growth stage and deactivate others
        for (int i = 0; i < growthStages.Length; i++)
        {
            growthStages[i].SetActive(i == currentStage);
        }
    }
}
