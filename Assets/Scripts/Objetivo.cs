using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objetivo : MonoBehaviour
{

	public string nome;
	public bool condicao;
	public Canvas canvas;

	public Objetivo (string nome, Canvas canvas) {
		this.nome = nome;
		this.canvas = canvas;
	}

    public string getNome () {
        return this.nome;
    }

    public Canvas getCanvas () {
    	return this.canvas;
    }

    public void enable () {

    }

    public void disable () {}

}
