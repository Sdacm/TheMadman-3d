using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local : MonoBehaviour
{
    
	private string nome;

	public Local (string nome) {
		this.nome = nome;
	}

	public string getNome () {
		return this.nome;
	}

}
