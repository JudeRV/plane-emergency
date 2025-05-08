using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandleSceneTransition : MonoBehaviour
{
    public float rotationLimit = 90f;
    public float fadeSpeed = 1f;
    public string nextSceneName = "raft";
    public Image fadeImage;

    private bool isPulled = false;
    private bool isFading = false;
    private float currentFade = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Make sure rigidbody is set up for physics interaction
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is a Leap Motion hand
        if (collision.gameObject.CompareTag("LeapHand"))
        {
            // The hand can now physically interact with the handle
            rb.isKinematic = false;
        }
    }

    void Update()
    {
        float currentAngle = transform.localEulerAngles.z;
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