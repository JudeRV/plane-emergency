using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{
    public float timeToNextScene = 60f; // 1 minute
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToNextScene)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("Reached the final scene.");
            // You can loop or quit here:
            // SceneManager.LoadScene(0); // loop
            // Application.Quit(); // quit
        }
    }
}
