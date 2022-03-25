// Esse código foi feito baseado neste tutorial: https://www.youtube.com/watch?v=6OT43pvUyfY, e também utilizado anteriormente em outro projeto chamado "Breakout!

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public AudioClip Background;

    private static AudioManager _instance;
    
    private void Awake() {

        foreach (Sound sound in sounds) {
            _instance = this;

            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    private void Start() {
        Play(Background);
    }

    public static void Play(AudioClip audioClip) {
        Sound sound = Array.Find(_instance.sounds, s => s.clip.name == audioClip.name);
        sound.source.Play();
    }

    public static void Stop(AudioClip audioClip) {
        Sound sound = Array.Find(_instance.sounds, s => s.clip.name == audioClip.name);
        sound.source.Stop();
    }
}
