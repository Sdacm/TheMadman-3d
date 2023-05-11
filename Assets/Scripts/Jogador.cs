using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{

	private string nome;
	private Objetivo objetivo;
	private List <Evento> cartas = new List <Evento> ();

	public Jogador (string nome) {
		this.nome = nome;
	}

	public string getNome () {
		return this.nome;
	}

	public void setObjetivo (Objetivo obj) {
		this.objetivo = obj;
	}

	public Objetivo getObjetivo () {
		return this.objetivo;
	}

	public List <Evento> getCartas () {
		return this.cartas;
	}

	public void addCarta (Evento e) {
		this.cartas.Add(e);
	}

	public string cartasToString(){
		string str = "[";
		for(int i = 0; i < cartas.Count; i++){
			str += (cartas[i].getId() + ", "); 
		}
		return str + "]";
	}

}
