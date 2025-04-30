using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeAndEndScene : MonoBehaviour
{
    public GameObject mask;
    public Camera mainCamera;
    public float maskDistanceThreshold = 0.1f;

    public Image fadeImage;
    public float fadeSpeed = 1f;

    private bool shouldFade = false;
    private bool fadeComplete = false;

    void Update()
    {
        if (!shouldFade)
        {
            if (mask == null)
            {
                Debug.LogWarning("Mask GameObject is not assigned.");
                return;
            }
            if (mainCamera == null)
            {
                Debug.LogWarning("Main Camera is not assigned.");
                return;
            }
            if (Vector3.Distance(mask.transform.position, mainCamera.transform.position) < maskDistanceThreshold)
            {
                shouldFade = true;
            }
        }
        else
        {
            // Start fading to black
            if (fadeImage != null)
            {
                Color color = fadeImage.color;
                color.a += fadeSpeed * Time.deltaTime;
                fadeImage.color = color;

                if (color.a >= 1f && !fadeComplete)
                {
                    fadeComplete = true;
                    EndScene();
                }
            }
        }
    }

    void EndScene()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }
}

