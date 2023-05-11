using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peao : MonoBehaviour
{
    private int loucura = 0;
	private int saude = 50;
	private int dinheiro = 30;
	private int trabalho = 50;
	private int amor = 50;
	private int social = 50;

	private Local local;

	public Peao(Local local) {
		this.local = local;
	}

	public int getLoucura() {
		return this.loucura;
	}

	public void atualizaLoucura (int n) {
		this.loucura = atualiza (this.loucura, n);;
	}
	
	public int getSaude () {
		return this.saude;
	}

	public void atualizaSaude (int n) {
		this.saude = atualiza (this.saude, n);;
	}

	public int getDinheiro () {
		return this.dinheiro;
	}

	public void atualizaDinheiro (int n) {
		this.dinheiro = atualiza (this.dinheiro, n);;
	}

	public int getTrabalho () {
		return this.trabalho;
	}

	public void atualizaTrabalho (int n) {
		this.trabalho = atualiza (this.trabalho, n);
	}

	public int getAmor () {
		return this.amor;
	}

	public void atualizaAmor (int n) {
		this.amor = atualiza (this.amor, n);
	}

	public int getSocial () {
		return this.social;
	}

	public void atualizaSocial (int n) {
		this.social = atualiza (this.social, n);
	}

	public void setLocal(Local l) {
		this.local = l;
	}

	public int atualiza (int c, int n) {
		if ((c + n) < 0) return 0;
		if ((c + n) > 100) return 100;
		return (c + n);
	}

	public Local getLocal(){
		return this.local;
	}

}
