using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento : MonoBehaviour
{

	private int id;
	private bool usado = false;
	private int pontos1, pontos2;
	private string atributo1, atributo2;
	private GameObject objetoCarta;
	private Local local;

	public Evento (int id, int pontos1, int pontos2, string atributo1, string atributo2, GameObject objetoCarta, Local local) {
		this.id = id;
		this.pontos1 = pontos1;
		this.pontos2 = pontos2;
		this.atributo1 = atributo1;
		this.atributo2 = atributo2;
		this.objetoCarta = objetoCarta;
	}

    public void aplica (Peao p) {
    	if(p.getLocal() == this.local){
    		pontos1 *=2;
    		pontos2 *=2;
    	}
    	switch (atributo1) {
			case "loucura":
				p.atualizaLoucura(pontos1);
				break;
			case "saude":
				p.atualizaSaude(pontos1);
				break;
			case "dinheiro":
				p.atualizaDinheiro(pontos1);
				break;
			case "amoroso":
				p.atualizaAmor(pontos1);
				break;
			case "trabalho":
				p.atualizaTrabalho(pontos1);
				break;
			case "social":
				p.atualizaSocial(pontos1);
				break;
			default:
				break;
		}
		switch (atributo2) {
			case "0":
				break;
			case "loucura":
				p.atualizaLoucura(pontos2);
				break;
			case "saude":
				p.atualizaSaude(pontos2);
				break;
			case "dinheiro":
				p.atualizaDinheiro(pontos2);
				break;
			case "amoroso":
				p.atualizaAmor(pontos2);
				break;
			case "trabalho":
				p.atualizaTrabalho(pontos2);
				break;
			case "social":
				p.atualizaSocial(pontos2);
				break;
			default:
				break;
		}
    }

    public int getId () {
    	return this.id;
    }

    public int getP1 () {
    	return this.pontos1;
    }

    public int getP2 () {
    	return this.pontos2;
    }

    public string getA1 () {
    	return this.atributo1;
    }

    public string getA2 () {
    	return this.atributo2;
    }

    public GameObject getObjetoCarta () {
    	return this.objetoCarta;
    }

    public Local getLocal () {
    	return this.local;
    }

}
