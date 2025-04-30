using UnityEngine;

public class MenuButtonBehavior : MonoBehaviour
{
    public GameObject interactables;

    public void OnHandContactEnter()
    {
        // Change the color of the button to indicate interaction
        GetComponentInChildren<Renderer>().material.color = Color.red;
    }
    public void OnHandContactLeave()
    {
        // Change the color of the button to indicate interaction
        GetComponentInChildren<Renderer>().material.color = Color.white;
    }

    public void OnPlayButtonPressed()
    {
        GameObject menuPanel = GameObject.Find("3D Menu Panel");
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
            interactables.SetActive(true);
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
