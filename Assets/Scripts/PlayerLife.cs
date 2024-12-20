﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

	private Rigidbody2D rb;
	private Animator anim;
	
	[SerializeField] private AudioSource deathSfx;

	private void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Die(); //si toca el enemigo se muere Luigi
		}
	}

	private void Die()
	{
		deathSfx.Play();
		rb.bodyType = RigidbodyType2D.Static;
 		anim.SetTrigger("death"); //este trigger carga de nuevo la escena
	}


	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); //funcion llamada mediante el animador
	}
}
