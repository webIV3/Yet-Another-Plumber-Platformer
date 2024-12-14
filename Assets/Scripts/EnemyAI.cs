using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour { 
	//LOS ENEMIGOS AL TOCAR UNA PARED SE ATORAN TODAVIA NO SE COMO ARREGLAR ESO NI TAMPOCO SE SI LO PODRE ARREGLAR
	//no quiero llegar a usar sistema de waypoints para el movimiento de enemigos oh no

	public float speed;
	public Rigidbody2D rb;
	bool facingLeft; //Para que el enemigo cambie de dirección

 // Use this for initialization
	 void Start ()
	 {
		rb = GetComponent<Rigidbody2D>();
 	 }
 
 // Update is called once per frame
	 void Update ()
	 {
		transform.Translate(Vector2.left * speed * Time.deltaTime);	//movimiento
	 }

	 void OnCollisionEnter2D(Collision2D collision)
	 {
		if (collision != null && !collision.collider.CompareTag("Player") && collision.collider.CompareTag("Wall"))
		//tag diferente para las paredes donde el enemigo colisiona porque si esta bajo el tag de Ground, el enemigo al tocar una pared se atora
		{
			facingLeft = !facingLeft;
		}

		if (collision != null && !collision.collider.CompareTag("Player") && collision.collider.CompareTag("Enemy"))
		{
			facingLeft = !facingLeft;
		}

		if (facingLeft)
		{
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else
		{
			gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
		}
	 }


}