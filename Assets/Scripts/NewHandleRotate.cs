using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandleSceneTransition : MonoBehaviour
{
    public float rotationLimit = 90f;      // Degrees to rotate before triggering
    public float fadeSpeed = 1f;           // Speed of fade to black
    public string nextSceneName = "raft"; // Scene to load
    public Image fadeImage;                // UI Image (black, full screen)
    
    private bool isPulled = false;
    private bool isFading = false;
    private float currentFade = 0f;

    void Update()
    {
        float currentAngle = transform.localEulerAngles.x;
        if (currentAngle > 180) currentAngle -= 360; // Normalize angle

        if (!isPulled && Mathf.Abs(currentAngle) >= rotationLimit - 5f) // Allow margin
        {
            isPulled = true;
            isFading = true;
        }

        if (isFading)
        {
            currentFade += Time.deltaTime * fadeSpeed;
            Color c = fadeImage.color;
            c.a = Mathf.Clamp01(currentFade);
            fadeImage.color = c;

            if (c.a >= 1f)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
