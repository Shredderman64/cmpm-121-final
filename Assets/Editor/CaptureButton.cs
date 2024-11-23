using UnityEngine;
using UnityEngine.UI;

public class CaptureButtonHandler : MonoBehaviour
{
    public PrefabToPNG prefabToPNG; // Reference to the PrefabToPNG script
    public GameObject prefabToCapture; // The prefab you want to capture as a PNG

    public Button captureButton; // Reference to the UI button

    void Start()
    {
        // Ensure the button has the method hooked up on click
        captureButton.onClick.AddListener(OnCaptureButtonClick);
    }

    // Method that gets called when the button is clicked
    void OnCaptureButtonClick()
    {
        // Capture the prefab and save it as a PNG
        if (prefabToPNG != null && prefabToCapture != null)
        {
            prefabToPNG.CapturePrefab(prefabToCapture);
        }
    }
}
