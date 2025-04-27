using System.Collections;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    public Animator animator;
    public AudioClip[] audioClips;

    private AudioSource audioSource;
    private int currentClipIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioClips.Length > 0)
        {
            audioSource.clip = audioClips[currentClipIndex];
        }
    }

    public void StartAnimation()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        StartCoroutine(BehaviorLoop());
    }

    private IEnumerator BehaviorLoop()
    {
        // Idle
        animator.SetBool("isWalking", false);
        animator.SetBool("isTalking", false);
        yield return new WaitForSeconds(2f);

        // Walk
        animator.SetBool("isWalking", true);
        yield return new WaitForSeconds(.5f);

        // Stop (Idle)
        animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(1.0f);

        // Talk
        animator.SetBool("isTalking", true);
        if (audioSource != null && audioClips.Length > 0)
        {
            // Play the first two clips (intro & refreshments)
            yield return StartCoroutine(PlayAndAdvanceClip());
            yield return StartCoroutine(PlayAndAdvanceClip());
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClips not set.");
            yield return new WaitForSeconds(5f);
        }        

        // Stop Talking, Walk again
        animator.SetBool("isTalking", false);
        animator.SetBool("isWalking", true);
        yield return new WaitForSeconds(5.0f);

        // Stop
        animator.SetBool("isWalking", false);
    }

    private IEnumerator PlayAndAdvanceClip()
    {
        if (audioSource != null && audioClips.Length > 0)
        {
            // Play the current clip
            audioSource.Play();
            yield return new WaitForSeconds(audioClips[currentClipIndex].length);

            // Advance to the next clip
            currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
            audioSource.clip = audioClips[currentClipIndex];
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClips not set.");
            yield return null;
        }
    }
}

