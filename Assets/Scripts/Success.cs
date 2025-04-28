using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeAndEndScene : MonoBehaviour
{
    public GameObject mask;                 // Assign your mask object here
    public Vector2 targetCenter;             // The center of the target range
    public Vector2 targetSize = new Vector2(1f, 1f); // Size of the target range (width, height)

    public Image fadeImage;                  // A UI Image (full screen, black, with alpha 0 initially)
    public float fadeSpeed = 1f;              // How fast to fade to black

    private bool shouldFade = false;
    private bool fadeComplete = false;

    void Update()
    {
        if (!shouldFade)
        {
            // Check if mask is within the target area
            Vector2 maskPos = new Vector2(mask.transform.position.x, mask.transform.position.y);
            if (IsWithinRange(maskPos))
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

    bool IsWithinRange(Vector2 pos)
    {
        return Mathf.Abs(pos.x - targetCenter.x) <= targetSize.x / 2f &&
               Mathf.Abs(pos.y - targetCenter.y) <= targetSize.y / 2f;
    }

    void EndScene()
    {
        // You can load another scene or quit
        // Example: Load the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Or just quit the application if needed
        // Application.Quit();
    }
}

