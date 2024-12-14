using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

	
	public void StartGame ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //si le da a start comienza el primer nivel o sea la siguiente escena
	}

	void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			Application.Quit(); //si presiona ESC se cierra el JUEGO
		}
	}

}
