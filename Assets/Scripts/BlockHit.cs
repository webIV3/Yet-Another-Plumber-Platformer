using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BlockHit : MonoBehaviour
{

	public float bounceHeight = 0.2f;
	public float bounceSpeed = 0.1f;

	public float coinMoveSpeed = 8f;
	public float coinMoveHeight = 3f;
	public float coinFallDistance = 2f;

	private Vector2 originalPosition;

	public Sprite emptyBlockSprite;

	private bool canBounce = true;

	public GameObject coin;

	[SerializeField] public AudioSource dropCoin;

	//Este código está un poco desorganizado pero bueno

	void Start()
	{
		originalPosition = transform.localPosition;
		
	}

	public void QuestionBlockBounce()
	{
		if (canBounce)
		{
			canBounce = false;

			StartCoroutine(Bounce());
		}
	}

	void ChangeSprite()
	{
		GetComponent<Animator>().enabled = false;
		GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
	}

	void PresentCoin()
	{
		GameObject spinningCoin = Instantiate(coin); 
		dropCoin.Play();
		
		spinningCoin.transform.SetParent (this.transform.parent);
		spinningCoin.transform.localPosition = new Vector2 (originalPosition.x, originalPosition.y + 1);

		StartCoroutine (MoveCoin (spinningCoin));
	}
	

	IEnumerator Bounce() //Hace que el bloque ? se vuelva un bloque sin nada
	{
		ChangeSprite();

		PresentCoin();

		while (true)
		{
			transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y + bounceSpeed * Time.deltaTime);
			
			if (transform.localPosition.y >= originalPosition.y + bounceHeight)
				break;

			yield return null;
		}

		while (true)
		{
			transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y - bounceSpeed * Time.deltaTime);
			
			if (transform.localPosition.y <= originalPosition.y)
			{
				transform.localPosition = originalPosition;
				break;
			}

			yield return null;
		}
	}

	IEnumerator MoveCoin (GameObject coin) //Animacion que mueve la moneda hacia arriba
	{
		while (true)
		{
			coin.transform.localPosition = new Vector2 (coin.transform.localPosition.x, coin.transform.localPosition.y + coinMoveSpeed * Time.deltaTime);

			if (coin.transform.localPosition.y >= originalPosition.y + coinMoveHeight + 1)
				break;
			
			yield return null;
		}

		while (true)
		{

			coin.transform.localPosition = new Vector2 (coin.transform.localPosition.x, coin.transform.localPosition.y - coinMoveSpeed * Time.deltaTime);

			if (coin.transform.localPosition.y <= originalPosition.y + coinFallDistance + 1)
			{
				Destroy(coin.gameObject);
				break;
			}
			
			yield return null; 
		}
	}
}
