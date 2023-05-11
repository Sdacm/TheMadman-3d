using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{

	public int jogadores = -1;

	public void PlayGame () {
		SceneManager.LoadScene("socorro");
	}

	public void HandleInputData (int n) {
		switch (n) {
			case 0:
				jogadores = 2;
				break;
			case 1:
				jogadores = 3;
				break;
			case 2:
				jogadores = 4;
				break;
			case 3:
				jogadores = 5;
				break;
			case 4:
				jogadores = 6;
				break;
			case 5:
				jogadores = 7;
				break;
			case 6:
				jogadores = 8;
				break;
			default:
				jogadores = 2;
				break;
		}
	}

	public int getJogadores () {
    	return this.jogadores;
    }
}
