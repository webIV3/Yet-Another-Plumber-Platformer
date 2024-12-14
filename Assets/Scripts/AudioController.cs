using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	private AudioSource bgm;

	void Start()
	{
		bgm = GetComponentInParent<AudioSource>();
	}

	void Update()
	{
		if (PauseMenu.isPaused)
		{
			bgm.Pause();
		}
		else
		{
			bgm.UnPause();
		}
	}
}
