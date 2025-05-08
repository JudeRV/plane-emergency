using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EndGame : MonoBehaviour
{
    [Header("Boat Settings")]
    public float boatSpeed = 3f;          // Constant forward speed
    private Vector3 _moveDirection;       // Starting forward direction

    [Header("Camera Follow")]
    public Transform boat; // Assign boat transform
    public XROrigin xROrigin; // Assign XR Rig transform
    private Vector3 _positionOffset;

    [Header("Activation")]
    public RopeSuccess successTracker; // Assign the script that tracks success
    public AudioSource successAudio; // Assign the success audio source
    public AudioClip[] audioClips; // Assign the audio clips for the boat

    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;

    private bool _isRidingBoat = false;

    void Start()
    {
        _moveDirection = boat.forward;

        _positionOffset = xROrigin.transform.position - boat.position;
    }

    void Update()
    {
        // Start riding ONLY when level succeeds
        if (!_isRidingBoat && successTracker.isLevelSuccessfull)
        {
            _isRidingBoat = true;
            StartCoroutine(EndTheGame());
        }

        if (_isRidingBoat)
        {
            boat.position += _moveDirection * boatSpeed * Time.deltaTime;
            // Smooth position follow
            Vector3 targetPosition = boat.position + boat.TransformDirection(_positionOffset);
            xROrigin.transform.position = Vector3.Lerp(
                xROrigin.transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
        }
    }

    IEnumerator EndTheGame()
    {
        yield return new WaitForSeconds(1f);
        successAudio.volume = 0.5f;
        successAudio.clip = audioClips[0];
        successAudio.Play();
        while (successAudio.isPlaying)
        {
            yield return null;
        }
        successAudio.volume = 1f;
        successAudio.clip = audioClips[1];
        successAudio.Play();
        while (successAudio.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}