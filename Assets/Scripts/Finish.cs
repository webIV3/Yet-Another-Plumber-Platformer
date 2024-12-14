using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

	private AudioSource finishSound;
	private bool levelCompleted = false;
	private void Start () 
	{
		finishSound = GetComponent<AudioSource>();
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !levelCompleted) //Si toca el final, suena el sonido y se cambia a la siguiente escena
		{
			finishSound.Play();
			levelCompleted = true; //evitar que sonido de victoria suene dos veces
			Invoke("CompleteLevel", 2f);
		}
	}

	private void CompleteLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
