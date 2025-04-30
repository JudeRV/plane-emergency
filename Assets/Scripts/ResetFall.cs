using UnityEngine;

public class ResetFall : MonoBehaviour
{
    public float fallThreshold = 1f; // The height at which the object will be reset
    private Vector3 startPosition; // The starting position of the object

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) > fallThreshold)
        {
            transform.position = startPosition;
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
