using System.Collections;
using UnityEngine;

public class LifeJacketStart : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips; // Assign your audio clips in the inspector
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartRoutine());
    }

    IEnumerator StartRoutine()
    {
        yield return new WaitForSeconds(1f);
        audioSource.clip = audioClips[0];
        audioSource.Play(); // Play turbulence voice line
        yield return new WaitForSeconds(audioSource.clip.length + 2f); // Wait for the clip to finish
        audioSource.clip = audioClips[1];
        audioSource.Play(); // Play 
    }
}
