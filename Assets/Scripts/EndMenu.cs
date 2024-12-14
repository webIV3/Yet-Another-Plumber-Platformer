using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour {

	void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			Application.Quit(); //si el jugador decide presionar esc entocnes se CIERRA EL JUEGO
		}
	}
	public void Quit()
	{
		Application.Quit(); //al darle al boton cierra el juego
	}

	public void StartAgain()
	{
		SceneManager.LoadScene("Level 1");
	}
}
