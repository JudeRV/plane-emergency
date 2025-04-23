using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroSleepTimer : MonoBehaviour
{
    public Image fadeImage; // Assign your BlackFade image here
    public float sleepStartTime = 50f;
    public float fadeDuration = 3f;
    public AudioSource backgroundAudio; // Optional

    private float timer = 0f;
    private bool isFading = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (!isFading && timer >= sleepStartTime)
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        isFading = true;

        float fadeTimer = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(0, 0, 0, 1);
        float startVolume = backgroundAudio ? backgroundAudio.volume : 0f;

        while (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            float t = fadeTimer / fadeDuration;

            fadeImage.color = Color.Lerp(startColor, endColor, t);

            if (backgroundAudio)
                backgroundAudio.volume = Mathf.Lerp(startVolume, 0f, t);

            yield return null;
        }

        // After fade completes, load the next scene
        SceneManager.LoadScene("mask");
    }
}

