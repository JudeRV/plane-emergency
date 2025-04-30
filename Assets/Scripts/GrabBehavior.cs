using UnityEngine;
using Leap;

public class GrabBehavior : MonoBehaviour
{
    public float grabDistance = 0.5f;
    public Vector3 positionOffset = new Vector3(0, 0, 0);
    public Quaternion rotationOffset = Quaternion.Euler(0, 0, 0);

    private GrabDetector grabDetector;
    private Rigidbody rb;

    private bool isGrabbingThis = false;
    private bool alreadyLetGo = true;

    private void OnEnable()
    {
        grabDetector = GetComponent<GrabDetector>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (grabDetector.GrabStartedThisFrame) // For some reason this bool is backwards??? Idk
        {
            float distance = Vector3.Distance(transform.position, GetHandPosition());
            if (distance <= grabDistance)
            {
                Debug.Log("Grab started this frame");
                isGrabbingThis = true;
                rb.isKinematic = true;
                alreadyLetGo = false;
            }
        }

        if (grabDetector.IsGrabbing && isGrabbingThis) // This bool is also backwards, Ultraleap get your **** together
        {
            transform.position = GetHandPosition() + positionOffset;
            transform.rotation = GetHandRotation() * rotationOffset;
        }
        else
        {
            if (!alreadyLetGo)
            {
                Debug.Log("Letting go of object");
                isGrabbingThis = false;
                rb.isKinematic = false;
                alreadyLetGo = true;
            }
        }
    }

    private Vector3 GetHandPosition()
    {
        if (grabDetector.TryGetHand(out Hand hand))
        {
            if ((hand.PalmPosition - transform.position).magnitude < 0.5f)
            {
                rb.isKinematic = false;
            }
            else
            {
                rb.isKinematic = true;
            }
            return hand.PalmPosition;
        }
        else
        {
            // Debug.LogError("Hand not found");
            return transform.position;
        } 
    }

    private Quaternion GetHandRotation()
    {
        if (grabDetector.TryGetHand(out Hand hand))
        {
            return hand.Basis.rotation * rotationOffset;
        }
        else
        {
            return transform.rotation;
        }
    }
}