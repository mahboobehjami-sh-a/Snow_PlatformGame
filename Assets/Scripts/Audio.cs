using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Audio
{
    public string name;
    public AudioClip clip ;
    [Range(0f,5f)]
    public float volume;

    [Range(0.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source ;
    // Start is called before the first frame update
    void Start()
    {
        // source = new AudioSource();
    }

    // Update is called once per frame
    void Update()
    {
        // source = new AudioSource();
    }
}
