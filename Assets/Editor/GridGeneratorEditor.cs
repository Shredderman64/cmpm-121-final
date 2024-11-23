#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class GridGeneratorEditor : MonoBehaviour
{
    public GameObject tilePrefab;  // Assign your tile prefab in the Inspector
    public int rows = 10;          // Number of rows
    public int columns = 10;       // Number of columns
    public float tileSize = 2f;    // Size of each tile

    [ContextMenu("Generate Grid")]
    void GenerateGrid()
    {
        if (tilePrefab == null)
        {
            Debug.LogError("Tile prefab is not assigned!");
            return;
        }

        // Clear existing tiles
        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }

        // Generate tiles
        for (int x = 0; x < columns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                Vector3 position = new Vector3(x * tileSize, -0.5f, z * tileSize);
                //un comment this line to get it working again. It was commented to allow building of project
                GameObject tile = PrefabUtility.InstantiatePrefab(tilePrefab, transform) as GameObject;
                tile.transform.position = position;
            }
        }
        Debug.Log("Grid generated in the editor!");
    }
}
