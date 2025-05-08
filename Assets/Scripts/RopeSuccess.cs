using UnityEngine;

public class RopeSuccess : MonoBehaviour
{
    private Vector3 startPosition;
    public bool isLevelSuccessfull = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the object is at least 10 units DOWN from the start position
        if (!isLevelSuccessfull && transform.position.y < startPosition.y - 10)
        {
            isLevelSuccessfull = true;
        }
    }
}
