using UnityEngine;

public class MenuButtonBehavior : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        GameObject menuPanel = GameObject.Find("3D Menu Panel");
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("3D Menu Panel not found in the scene.");
        }
    }
    public void OnQuitButtonPressed()
    {
        // Quit the application
        Application.Quit();
        // If running in the editor, stop playing
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
