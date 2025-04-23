using UnityEngine;

public class TimedCameraMover : MonoBehaviour
{
    public float moveSpeed = 2f;         // Walking speed (units per second)
    public float moveDuration = 2f;      // How long to move (4 feet ≈ 1.2m, at 2m/s = 0.6s per meter)
    public float delayBeforeMove = 3f;   // Seconds to wait before starting

    private float timer = 0f;
    private bool isMoving = false;
    private float moveTimer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (!isMoving && timer >= delayBeforeMove)
        {
            isMoving = true;
        }

        if (isMoving && moveTimer < moveDuration)
        {
            Vector3 forward = transform.forward;
            forward.y = 0;
            forward.Normalize();

            transform.position += forward * moveSpeed * Time.deltaTime;
            moveTimer += Time.deltaTime;
        }
    }
}
