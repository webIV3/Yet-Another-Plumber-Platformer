﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	Rigidbody2D rb;
	Vector2 defaultPos;

	[SerializeField] float fallDelay, respawnTime;

	void Start () {
		defaultPos = transform.position;
		rb = GetComponent<Rigidbody2D>();
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			StartCoroutine("PlatformDrop");
		}
	}

	IEnumerator PlatformDrop()
	{
		yield return new WaitForSeconds(fallDelay);
		rb.bodyType = RigidbodyType2D.Dynamic;
		yield return new WaitForSeconds(respawnTime);
		Reset();
	}

	private void Reset()
	{
		rb.bodyType = RigidbodyType2D.Static;
		transform.position = defaultPos;
	}

}
