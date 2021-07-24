using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;
    private int index;
    private AudioSource source;
    public static MusicManager instance = null;
    public static bool isMusicOn;
    // Start is called before the first frame update
    void Start()
    {
        isMusicOn = true;
        if (instance == null)
        { 
            instance = this; 
        }
        else if (instance == this)
        { 
            Destroy(gameObject); 
        }

        
        source = GetComponent<AudioSource>();
        source.Play();

        DontDestroyOnLoad(gameObject);
        
    }


    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {

            PlaySong();
        }
    }
    private void PlaySong()
    {
        index = Random.Range(0, music.Length);
        source.clip = music[index];
        source.Play();
    }
    public void SwitchMute()
    {
        isMusicOn = !isMusicOn;
        source.mute = !source.mute;
    }
}
