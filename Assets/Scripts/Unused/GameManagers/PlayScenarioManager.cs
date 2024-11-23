using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayScenarioManager : MonoBehaviour
{
    public int targetFullyGrownPlants = 2; // Number of fully grown plants needed to complete the scenario
    public UnityEvent OnScenarioComplete;  // Event triggered when the scenario is complete
    [SerializeField] private GameObject panelToActivate; // Assign the panel in the Inspector

    private void Start()
    {
        TimeManager timeManager = FindObjectOfType<TimeManager>();
        if (timeManager != null)
        {
            timeManager.OnNextDay.AddListener(CheckPlayCondition);
        }
        else
        {
            Debug.LogError("TimeManager not found in the scene!");
        }
    }

    private void CheckPlayCondition()
    {
        // Get all plants in the scene
        Plant[] plants = FindObjectsOfType<Plant>();
        int fullyGrownPlantsCount = 0;

        foreach (Plant plant in plants)
        {
            // Check if the plant is in its final growth stage
            if (plant.currentStage == plant.growthStages.Length - 1)
            {
                fullyGrownPlantsCount++;
            }
        }

        // Check if the scenario condition is met
        if (fullyGrownPlantsCount >= targetFullyGrownPlants)
        {
            if (panelToActivate != null)
            {
                ObjectivesManager.Instance.CompleteObjective(3);
                panelToActivate.SetActive(true);
                Debug.Log("Play scenario completed!");
                OnScenarioComplete?.Invoke();
            }
            else
            {
                Debug.LogWarning("No panel assigned in " + gameObject.name);
            }
    
        }
    }
}
