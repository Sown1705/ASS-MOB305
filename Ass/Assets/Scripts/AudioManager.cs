using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public GameObject prefab;
    public AudioClip coin;
    public AudioSource coinSource;
	// Start is called before the first frame update
	private void Awake()
	{
        instance = this;
	}
    public void PlaySound(AudioClip clip, float volume, bool isLoopback)
	{
		if (clip == this.coin) {
            Play(clip, ref coinSource, volume, isLoopback);
        }
	}
    public void PlaySound(AudioClip clip,float volume)
	{
		if (clip == this.coin)
		{
            Play(clip, ref coinSource, volume);
            return;
		}
	}

	private void Play(AudioClip clip, ref AudioSource audioSource, float volume, bool isLoopback=false)
	{
		if(audioSource !=null && audioSource.isPlaying)
		{
            return;
		}
        audioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();//lay doi tuong

        audioSource.volume = volume;
        audioSource.loop = isLoopback;
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
	}
    public void StopSound(AudioClip clip)
	{
		if (clip == this.coin)
		{
            coinSource?.Stop();//neu !=null thi stop
            return;
		}
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
