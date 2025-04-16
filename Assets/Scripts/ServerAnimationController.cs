using System.Collections;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    public Animator animator;

    private void Start()
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
        yield return new WaitForSeconds(10f);

        // Walk
        animator.SetBool("isWalking", true);
        yield return new WaitForSeconds(.5f);

        // Stop (Idle)
        animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(1.0f);

        // Talk
        animator.SetBool("isTalking", true);
        yield return new WaitForSeconds(22f);

        // Stop Talking, Walk again
        animator.SetBool("isTalking", false);
        animator.SetBool("isWalking", true);
        yield return new WaitForSeconds(5.0f);

        // Stop
        animator.SetBool("isWalking", false);
    }
}

