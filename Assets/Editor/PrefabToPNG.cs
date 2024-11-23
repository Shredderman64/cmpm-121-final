using UnityEngine;
using System.IO;

public class PrefabToPNG : MonoBehaviour
{
    public Camera renderCamera; // Reference to the camera
    public RenderTexture renderTexture; // Reference to the render texture
    public string savePath = "Assets/Icons"; // Path to save PNGs

    public void CapturePrefab(GameObject prefab)
    {
        // Position the prefab
        GameObject instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);

        // Render the texture
        RenderTexture.active = renderTexture;
        renderCamera.Render();

        // Create a Texture2D
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();

        // Save as PNG
        byte[] bytes = texture.EncodeToPNG();
        string filePath = Path.Combine(savePath, prefab.name + ".png");
        File.WriteAllBytes(filePath, bytes);

        Debug.Log("Saved PNG to: " + filePath);

        // Cleanup
        RenderTexture.active = null;
        Destroy(instance);
    }
}
