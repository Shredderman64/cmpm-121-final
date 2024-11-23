using Unity.VisualScripting;
using UnityEngine;

public class SowPlant : MonoBehaviour
{
    public static SowPlant Instance;

    public GameObject plantMenuUI; // Reference to the plant selection UI
    private Tile selectedTile;
    public bool isUIOpen = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowPlantMenu(Tile tile)
    {
        selectedTile = tile;
        plantMenuUI.SetActive(true);
        isUIOpen = true;
        // Optionally, position the menu near the tile - potential feature when I have time - Isaac
    }

    public void PlantSelected(GameObject plantPrefab)
    {
        Vector3 position = new(selectedTile.Position.x, 0.5f, selectedTile.Position.y);
        Quaternion rotation = Quaternion.Euler(0f, -90f, 0f);
        if (selectedTile != null)
        {
            selectedTile.plantOnTile = Instantiate(plantPrefab, position, rotation);
            if (selectedTile.plantOnTile.CompareTag("CarrotPlant"))
            {
                Debug.Log("Carrot Planted");
                ObjectivesManager.Instance.CompleteObjective(1);
            }
            plantMenuUI.SetActive(false);
            isUIOpen = false;
            selectedTile = null;
        }
    }
}
