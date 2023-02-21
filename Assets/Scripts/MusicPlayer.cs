using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource[] AudioSource;

    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource[0].volume = musicVolume;
    }

    public void UpDateVolume(float volume)
    {
        musicVolume = volume;
    }
}
