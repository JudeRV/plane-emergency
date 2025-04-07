using UnityEngine;

public class ResetFall : MonoBehaviour
{
    private Vector3 startPosition; // The starting position of the object
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position; // Store the starting position
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10) // Check if the object has fallen below a certain height
        {
            transform.position = startPosition; // Reset the object's position to the starting position
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // Reset the object's velocity
        }
    }
}
