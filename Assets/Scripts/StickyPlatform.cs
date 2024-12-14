using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Luigi") //si luigi toca la plataforma que se mueve, hace que luigi se mueva junto a la plataforma
		{
			collision.gameObject.transform.SetParent(transform);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Luigi")
		{
			collision.gameObject.transform.SetParent(null); // si salta deja de ser parte de la plataforma
		}
	}
}
