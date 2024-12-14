using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreakableBrick : MonoBehaviour {

	[SerializeField] private UnityEvent _hit;

	private void OnCollisionEnter2D(Collision2D other)
	{
		var player = other.collider.CompareTag("Player");
		if (player && other.contacts[0].normal.y > 0) //Al entrar contacto con Luigi invoca el evento donde el bloque se "rompe"
		{
			_hit.Invoke();
		}
	}
}
