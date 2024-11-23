using UnityEngine;

public class TileInteractionHandler : MonoBehaviour
{
    private Renderer tileRenderer;
    private Renderer previousRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow;
    private GridManager gridManager;
    private float tileDistance;

    private void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        tileDistance = gridManager.GetTileSize();
    }

    private void Update()
    {
        if (SowPlant.Instance.isUIOpen) return;
        DetectObjectUnderMouse();
        if (tileRenderer && Input.GetMouseButtonDown(0))
            InteractWithTile();
    }
    private void DetectObjectUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Soil")))
        {
            GameObject hoveredObject = hit.collider.gameObject;
            tileRenderer = hoveredObject.GetComponent<Renderer>();
            if (tileRenderer && tileRenderer != previousRenderer)
            {
                ResetTileColor();
                previousRenderer = tileRenderer;
                originalColor = tileRenderer.material.color;
                tileRenderer.material.color = highlightColor;
            }
        }
        else
        {
            ResetTileColor();
            previousRenderer = null;
            tileRenderer = null;
        }
    }

    private void ResetTileColor()
    {
        if (previousRenderer)
            previousRenderer.material.color = originalColor;
    }

    private void InteractWithTile() {
        Tile tile = gridManager.GetTileAt(tileRenderer.transform.position);

        bool nearPlayerLeft = tile.Position.x >= transform.position.x - tileDistance;
        bool nearPlayerRight = tile.Position.x <= transform.position.x + tileDistance;
        bool nearPlayerUp = tile.Position.y <= transform.position.z + tileDistance;
        bool nearPlayerDown = tile.Position.y >= transform.position.z - tileDistance;
        bool nearPlayer = nearPlayerLeft && nearPlayerRight && nearPlayerUp && nearPlayerDown;

        if (!tile.isSowed && nearPlayer) {
            SowPlant.Instance.ShowPlantMenu(tile);
            tile.isSowed = true;
        }
        else if (tile.isSowed && nearPlayer){
            Destroy(tile.plantOnTile);
            tile.isSowed = false;
        }
    }
}