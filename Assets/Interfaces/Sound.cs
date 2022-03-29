// Esse código foi feito baseado neste tutorial: https://www.youtube.com/watch?v=6OT43pvUyfY, e também utilizado anteriormente em outro projeto chamado "Breakout!

using System;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[Serializable]
public class Sound {

    public AudioClip clip = default;

	[Range(0.0f, 1.0f)]
	public float volume = default;

	[Range(0.1f, 3.0f)]
    public float pitch = default;

	public bool loop = default;

	[HideInInspector]
	public AudioSource source = default;
}
