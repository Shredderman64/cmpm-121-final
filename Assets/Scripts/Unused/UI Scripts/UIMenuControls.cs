using UnityEngine;

public class UIPanelToggle : MonoBehaviour
{
    // Reference to the UI panel or GameObject to toggle
    [SerializeField] private GameObject panel;

    // Toggles the panel's active state
    public void TogglePanel()
    {
        if (panel != null)
        {
            // Set the panel to active if it's inactive, or inactive if it's active
            panel.SetActive(!panel.activeSelf);
        }
        else
        {
            Debug.LogWarning("Panel is not assigned in " + gameObject.name);
        }
    }

    // Ensures the panel is hidden when the game starts (optional)
    private void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Start with the panel hidden
        }
    }
}
