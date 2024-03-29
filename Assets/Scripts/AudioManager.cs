using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Audio[] sounds ;
    public static AudioManager instance ;

     void Awake() {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }
        // DontDestroyOnLoad(gameObject);

        foreach(Audio s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip ;
            s.source.volume = s.volume ; 
            s.source.pitch = s.pitch ; 
            s.source.loop = s.loop ; 
        }
    }

    public void PlaySound(string name){
        Audio s=Array.Find(sounds,sounds=>sounds.name == name );
        // s.source.Play();
        s.source.Play();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

