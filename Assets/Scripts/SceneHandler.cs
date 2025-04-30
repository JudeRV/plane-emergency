using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{
    public float secondsToNextScene = 120f;

    public Image fadeImage;
    public float fadeDuration = 2f;

    public void StartTimerToNextScene()
    {
        // Start the timer to load the next scene
        StartCoroutine(WaitForNextScene());
    }

    public IEnumerator WaitForNextScene()
    {
        yield return new WaitForSeconds(secondsToNextScene);        
        yield return StartCoroutine(FadeRoutine());
        LoadNextScene();
    }

    private IEnumerator FadeRoutine()
    {
        float elapsedTime = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(0, 0, 0, 1); // Black with full opacity

        while (elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = endColor; // Ensure fully black
    }

    public void LoadNextScene()
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
            SceneManager.LoadScene(0);
        }
    }
}
