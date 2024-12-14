using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
	public int coins = 0;

	[SerializeField] private Text coinsText;
	[SerializeField] public AudioSource collectCoin;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Coin")) //Si el jugador toca una moneda, esta se elimina y se añade a la cantidad de monedas
		{
			Destroy(collision.gameObject);
			collectCoin.Play();
			AddCoin();
			coinsText.text = "Coins x " + coins;
		}
	}

	public void AddCoin()
	{
		coins++;
	}

	private void OnCollisionEnter2D(Collision2D collision) //hacer el código de esto me tomo como 12 horas en total intentar averiguar como hacerlo, tuve que hacer otro BoxCollider dentro del propio bloque ? porque si no, el bloque daba monedas infinitas
	{
		if (collision.gameObject.CompareTag("QuestionBlock"))
		{
			collision.gameObject.GetComponentInParent<BlockHit>().QuestionBlockBounce();
			AddCoin();
			coinsText.text = "Coins x " + coins;
			Destroy(collision.gameObject);
		}
	}
}
