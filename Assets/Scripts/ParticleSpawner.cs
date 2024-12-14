using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour {

	[SerializeField] private GameObject obj;

	[SerializeField] private AudioSource brBrick;

	public void Spawn()
	{
		Instantiate(obj, transform.position, Quaternion.identity); //Usando el sistema de particulas de unity :nerd: , hace que salgan particulas de ladrillo roto :)
	}
}
