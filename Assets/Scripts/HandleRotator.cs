using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleRotator : MonoBehaviour
{
    public float rotationAngle = 90000f;
    public float rotationSpeed = 100f;
    public float fadeSpeed = 1f;
    public GameObject HandlePivot; // Reference to the pivot point
    
    private bool isRotating = true;  // Changed to false by default
    private bool isFading = false;
    private float currentRotation = 0f;
    private float fadeAmount = 0f;
    
    // Reference to a UI Image component for fading
    public UnityEngine.UI.Image fadeImage;

    void OnCollisionEnter(Collision other)
    {
        // Check if the colliding object is the player's hand
        if (other.gameObject.CompareTag("PlayerHand") && !isRotating)
        {
            isRotating = true;
        }
    }

    void Start()
    {
        // Create a sphere at the pivot point for debugging
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = HandlePivot.transform.position; // Set the position to the pivot point
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Scale down the sphere
        sphere.GetComponent<Renderer>().material.color = Color.red; // Change color to red for visibility
    }

    void Update()
    {
        // Handle rotation
        if (isRotating)
        {
            float rotateStep = rotationSpeed * Time.deltaTime;
            float remaining = rotationAngle - currentRotation;
            float rotationThisFrame = Mathf.Min(rotateStep, remaining);

            // Rotate around the pivot point's Z axis (local to the pivot)
            transform.Rotate(Vector3.forward, rotationThisFrame);
            currentRotation += rotationThisFrame;

            if (currentRotation >= rotationAngle)
            {
                isRotating = false;
                isFading = true;
            }
        }

        // Handle fading and scene transition
        if (isFading)
        {
            fadeAmount += fadeSpeed * Time.deltaTime;
            // Set all color channels to 0 (black) and use fadeAmount for alpha
            fadeImage.color = new Color(0f, 0f, 0f, fadeAmount);

            if (fadeAmount >= 1f)
            {
                SceneManager.LoadScene("SampleScene 2");
            }
        }
    }
}
