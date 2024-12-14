using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Killed : MonoBehaviour
{

	bool stomped = false;

	[SerializeField] private AudioSource squish;

	void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.CompareTag("Player"))
		{
			Rigidbody2D playerRb = trigger.GetComponent<Rigidbody2D>();
			playerRb.velocity = new Vector2(playerRb.velocity.x, 16f); //Hace que Luigi rebote al pisar al enemigo

			stomped = true;
			squish.Play();

			Animator anim = transform.parent.gameObject.GetComponent<Animator>();
			anim.SetTrigger("stomped"); //Animacion de aplastado

			BoxCollider2D boxCollider = transform.parent.gameObject.GetComponent<BoxCollider2D>();
			boxCollider.enabled = false;
		}
	}

	void OnBecameInvisible()
	{
		if (stomped == true)
		{
			Destroy(transform.parent.gameObject);
		}
	}
}
