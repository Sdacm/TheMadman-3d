using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene: MonoBehaviour
{
	public Menu menu;
	public int j;

	void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update () {
    	j = menu.jogadores;
        if (menu == null) {
            return;
        }
    }

    public SaveScene () {}

    public int getJogadores () {
    	return this.j;
    }

}
