using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTouch : MonoBehaviour
{
    public AudioClip[] touchSounds;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {

        int index = Random.Range(0, touchSounds.Length);


        audioSource.clip = touchSounds[index];
        audioSource.Play();
    }
}
