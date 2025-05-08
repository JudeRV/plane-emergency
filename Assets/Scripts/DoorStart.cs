using System.Collections;
using UnityEngine;

public class DoorStart : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(DoorStartBehavior());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DoorStartBehavior()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
    }
}
