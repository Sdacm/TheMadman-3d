using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public enum Estado {
    INICIAL,
    INTRODUZ_JOGADOR,
    MOSTRA_JOGO,
    DECIDE_CARTA,
    ESCONDE_JOGO,
    MUDA_DE_JOGADOR,
    MUDA_DE_LOCAL,
    FINAL
}

public class MadMan : MonoBehaviour
{
	
	public TextMeshProUGUI loucuraText;
	public TextMeshProUGUI saudeText;
	public TextMeshProUGUI dinheiroText;
	public TextMeshProUGUI trabalhoText;
	public TextMeshProUGUI amorText;
	public TextMeshProUGUI socialText;

    public TextMeshProUGUI inicialText;
    public TextMeshProUGUI introduzText;

    public TextMeshProUGUI finalText;

    public TextMeshProUGUI seleciona1Text;
    public TextMeshProUGUI seleciona2Text;
    public TextMeshProUGUI seleciona3Text;
    public TextMeshProUGUI seleciona4Text;
    public TextMeshProUGUI seleciona5Text;

	private Peao peao;

    public Canvas CanvasSaudavel;
    public Canvas CanvasDoente;
    public Canvas CanvasRico;
    public Canvas CanvasPobre;
    public Canvas CanvasTrabalhador;
    public Canvas CanvasDesleixado;
    public Canvas CanvasAmoroso;
    public Canvas CanvasSafado;
    public Canvas CanvasAmigo;
    public Canvas CanvasInimigo;

    public Canvas CanvasBoasVindas;
    public Canvas CanvasIntroduz;

    public Canvas CanvasFinal;

	private List <Jogador> jogadores = new List <Jogador> ();
    private List <Objetivo> objetivos = new List <Objetivo> ();
	private List <Evento> baralho = new List<Evento>();
	private List <Evento> memorias = new List<Evento>();
    private List <int> cartasNasMaos = new List <int> ();
    private List <Local> locais = new List <Local> ();

	private Random rnd = new Random(); 

	public SaveScene saveScene;

	int numJogadores = 0;
    int numCartas = 5;
    int numTotal = 0;

    bool termina;
    int jogadorAtual = 0;
    int localAtual = 0;

    private int cartaEscolhida = -1;

    public Camera cam;
    public Transform casaPos;
    public Transform trabalhoPos;
    public Transform hospitalPos;
    public Transform centroPos;
    public Transform ginasioPos;
    public Transform cafePos;

    public Transform posCarta1;
    public Transform posCarta2;
    public Transform posCarta3;
    public Transform posCarta4;
    public Transform posCarta5;
    public Transform posOut;

    public GameObject carta1;
    public GameObject carta2;
    public GameObject carta3;
    public GameObject carta4;
    public GameObject carta5;
    public GameObject carta6;
    public GameObject carta7;
    public GameObject carta8;
    public GameObject carta9;
    public GameObject carta10;
    public GameObject carta11;
    public GameObject carta12;
    public GameObject carta13;
    public GameObject carta14;
    public GameObject carta15;
    public GameObject carta16;
    public GameObject carta17;
    public GameObject carta18;
    public GameObject carta19;
    public GameObject carta20;
    public GameObject carta21;
    public GameObject carta22;
    public GameObject carta23;
    public GameObject carta24;
    public GameObject carta25;
    public GameObject carta26;
    public GameObject carta27;
    public GameObject carta28;
    public GameObject carta29;
    public GameObject carta30;
    public GameObject carta31;
    public GameObject carta32;
    public GameObject carta33;
    public GameObject carta34;
    public GameObject carta35;
    public GameObject carta36;
    public GameObject carta37;
    public GameObject carta38;
    public GameObject carta39;
    public GameObject carta40;
    public GameObject carta41;
    public GameObject carta42;
    public GameObject carta43;
    public GameObject carta44;
    public GameObject carta45;
    public GameObject carta46;
    public GameObject carta47;
    public GameObject carta48;
    public GameObject carta49;
	public GameObject carta50;
    public GameObject carta51;
    public GameObject carta52;
    public GameObject carta53;
    public GameObject carta54;
    public GameObject carta55;
    public GameObject carta56;
    public GameObject carta57;
    public GameObject carta58;
    public GameObject carta59;
    public GameObject carta60;
    public GameObject carta61;
    public GameObject carta62;
    public GameObject carta63;
    public GameObject carta64;
    public GameObject carta65;
    public GameObject carta66;
    public GameObject carta67;
    public GameObject carta68;
    public GameObject carta69;
    public GameObject carta70;
    public GameObject carta71;
    public GameObject carta72;
    public GameObject carta73;
    public GameObject carta74;
    public GameObject carta75;
    public GameObject carta76;
    public GameObject carta77;
    public GameObject carta78;
    public GameObject carta79;
    public GameObject carta80;
    public GameObject carta81;
    public GameObject carta82;

    private List <GameObject> objetosCarta = new List <GameObject> ();
    private List <Transform> posicoesCartas = new List <Transform> ();

    public Estado estadoAtual;

    private Evento nulo = new Evento (-1,-1,-1,"-1","-1",null,null);

    void Awake()
    {
        criaObjetivos ();

    	saveScene = GameObject.Find("SaveSceneObject").GetComponent<SaveScene>();
    	numJogadores = (saveScene.j >= 2) ? saveScene.j : 2;
    	//print("NUMERO DE JOGADORES::: " + numJogadores);

        numTotal = numCartas * numJogadores;

        criaLocais ();

        peao = new Peao (locais[localAtual]);

        atualizaValores ();
    	
    	criaJogadores(numJogadores);

    	List <int> js = new List <int> ();
    	for (int j = 0; j < numJogadores; j++) {
    		js.Add(-1);
    	}

    	int i = 0;
    	while (i < numJogadores) {
    		int abc = Random.Range(0,10);
    		if (!js.Contains(abc)) {
    			js[i] = abc;
    			jogadores[i].setObjetivo(objetivos[abc]);
    			//print(jogadores[i].getNome() + ": " + jogadores[i].getObjetivo().getNome());
    			i++;
    		}
    	}

        criaObjetosCarta();

    	criaBaralho();

        baralho = ShuffleList(baralho);

        // Lista de 83 inteiros preenchida com -1
        for (int j = 0; j < baralho.Count; j++) {
            cartasNasMaos.Add(-1);
            //print("PRIMEIRO ::: BARALHO [" + j + "]: " + baralho[j]);
        }

        for (int k = 0; k < numJogadores; k++) {
            //print("NO AWAKE ::: BARALHO [" + k + "]: " + baralho[k]);
            distribuiCartas(jogadores[k]);
            //print(jogadores[k].cartasToString());
        }

        disableCanvas();

        seleciona1Text.text = "";
        seleciona2Text.text = "";
        seleciona3Text.text = "";
        seleciona4Text.text = "";
        seleciona5Text.text = "";

        termina = false;
        estadoAtual = Estado.INICIAL;
        CanvasIntroduz.GetComponent<Canvas>().enabled = false;
        CanvasFinal.GetComponent<Canvas>().enabled = false;
        StartCoroutine(boasVindas());
       
    }

    IEnumerator boasVindas () {
        while (!Input.GetKeyDown(KeyCode.Space)){
            CanvasBoasVindas.GetComponent<Canvas>().enabled = true;
            //print("DENTRO DO WHILE");
            yield return null;
        }
        CanvasBoasVindas.GetComponent<Canvas>().enabled = false;
        estadoAtual = Estado.INTRODUZ_JOGADOR;
        StartCoroutine(introduzJogador(jogadores[jogadorAtual]));
        //print("FORA DO WHILE...");
        yield return null;
    }

    void criaJogadores (int n) {
    	for (int i = 0; i < n; i++) {
    		Jogador j = new Jogador("Jogador " + (i+1));
    		this.jogadores.Add(j);
    	}
    }

    void criaObjetivos () {
        Objetivo saudavel = new Objetivo ("Sáudavel", CanvasSaudavel);
        Objetivo doente = new Objetivo ("Doente", CanvasDoente);
        Objetivo rico = new Objetivo ("Rico", CanvasRico);
        Objetivo pobre = new Objetivo ("Pobre", CanvasPobre);
        Objetivo trabalhador = new Objetivo ("Trabalhador", CanvasTrabalhador);
        Objetivo desleixado = new Objetivo ("Desleixado", CanvasDesleixado);
        Objetivo amoroso = new Objetivo ("Amoroso", CanvasAmoroso);
        Objetivo safado = new Objetivo ("Safado", CanvasSafado);
        Objetivo amigo = new Objetivo ("Amigo", CanvasAmigo);
        Objetivo inimigo = new Objetivo ("Inimigo", CanvasInimigo);

        objetivos.Add(saudavel);
        objetivos.Add(doente);
        objetivos.Add(rico);
        objetivos.Add(pobre);
        objetivos.Add(trabalhador);
        objetivos.Add(desleixado);
        objetivos.Add(amoroso);
        objetivos.Add(safado);
        objetivos.Add(amigo);
        objetivos.Add(inimigo);
    }

    void criaLocais () {
        Local casa = new Local ("Casa");
        Local trabalho = new Local ("Trabalho");
        Local hospital = new Local ("Hospital");
        Local centro = new Local ("Centro Comercial");
        Local ginasio = new Local ("Ginásio");
        Local cafe = new Local ("Café");

        locais.Add(casa);
        locais.Add(trabalho);
        locais.Add(hospital);
        locais.Add(centro);
        locais.Add(ginasio);
        locais.Add(cafe);
    }

    void criaObjetosCarta () {
        objetosCarta.Add(carta1);
        objetosCarta.Add(carta2);
        objetosCarta.Add(carta3);
        objetosCarta.Add(carta4);
        objetosCarta.Add(carta5);
        objetosCarta.Add(carta6);
        objetosCarta.Add(carta7);
        objetosCarta.Add(carta8);
        objetosCarta.Add(carta9);
        objetosCarta.Add(carta10);
        objetosCarta.Add(carta11);
        objetosCarta.Add(carta12);
        objetosCarta.Add(carta13);
        objetosCarta.Add(carta14);
        objetosCarta.Add(carta15);
        objetosCarta.Add(carta16);
        objetosCarta.Add(carta17);
        objetosCarta.Add(carta18);
        objetosCarta.Add(carta19);
        objetosCarta.Add(carta20);
        objetosCarta.Add(carta21);
        objetosCarta.Add(carta22);
        objetosCarta.Add(carta23);
        objetosCarta.Add(carta24);
        objetosCarta.Add(carta25);
        objetosCarta.Add(carta26);
        objetosCarta.Add(carta27);
        objetosCarta.Add(carta28);
        objetosCarta.Add(carta29);
        objetosCarta.Add(carta30);
        objetosCarta.Add(carta31);
        objetosCarta.Add(carta32);
        objetosCarta.Add(carta33);
        objetosCarta.Add(carta34);
        objetosCarta.Add(carta35);
        objetosCarta.Add(carta36);
        objetosCarta.Add(carta37);
        objetosCarta.Add(carta38);
        objetosCarta.Add(carta39);
        objetosCarta.Add(carta40);
        objetosCarta.Add(carta41);
        objetosCarta.Add(carta42);
        objetosCarta.Add(carta43);
        objetosCarta.Add(carta44);
        objetosCarta.Add(carta45);
        objetosCarta.Add(carta46);
        objetosCarta.Add(carta47);
        objetosCarta.Add(carta48);
        objetosCarta.Add(carta49);
        objetosCarta.Add(carta50);
        objetosCarta.Add(carta51);
        objetosCarta.Add(carta52);
        objetosCarta.Add(carta53);
        objetosCarta.Add(carta54);
        objetosCarta.Add(carta55);
        objetosCarta.Add(carta56);
        objetosCarta.Add(carta57);
        objetosCarta.Add(carta58);
        objetosCarta.Add(carta59);
        objetosCarta.Add(carta60);
        objetosCarta.Add(carta61);
        objetosCarta.Add(carta62);
        objetosCarta.Add(carta63);
        objetosCarta.Add(carta64);
        objetosCarta.Add(carta65);
        objetosCarta.Add(carta66);
        objetosCarta.Add(carta67);
        objetosCarta.Add(carta68);
        objetosCarta.Add(carta69);
        objetosCarta.Add(carta70);
        objetosCarta.Add(carta71);
        objetosCarta.Add(carta72);
        objetosCarta.Add(carta73);
        objetosCarta.Add(carta74);
        objetosCarta.Add(carta75);
        objetosCarta.Add(carta76);
        objetosCarta.Add(carta77);
        objetosCarta.Add(carta78);
        objetosCarta.Add(carta79);
        objetosCarta.Add(carta80);
        objetosCarta.Add(carta81);
        objetosCarta.Add(carta82);

        posicoesCartas.Add(posCarta1);
        posicoesCartas.Add(posCarta2);
        posicoesCartas.Add(posCarta3);
        posicoesCartas.Add(posCarta4);
        posicoesCartas.Add(posCarta5);
    }

    void disableCanvas () {
        CanvasSaudavel.GetComponent<Canvas>().enabled = false;
        CanvasDoente.GetComponent<Canvas>().enabled = false;
        CanvasRico.GetComponent<Canvas>().enabled = false;
        CanvasPobre.GetComponent<Canvas>().enabled = false;
        CanvasTrabalhador.GetComponent<Canvas>().enabled = false;
        CanvasDesleixado.GetComponent<Canvas>().enabled = false;
        CanvasAmoroso.GetComponent<Canvas>().enabled = false;
        CanvasSafado.GetComponent<Canvas>().enabled = false;
        CanvasAmigo.GetComponent<Canvas>().enabled = false;
        CanvasInimigo.GetComponent<Canvas>().enabled = false;
        CanvasBoasVindas.GetComponent<Canvas>().enabled = false;
    }

    void criaBaralho() {
    	using(var reader = new StreamReader(@"C:\Users\Salvador\Desktop\Unity Projects\TheMadman 3D\Assets\Ficheiros\cartas.csv")) {
        	List<string> listId = new List<string>();
        	List<string> listPontos1 = new List<string>();
			List<string> listAtributo1 = new List<string>();
        	List<string> listPontos2 = new List<string>();
        	List<string> listAtributo2 = new List<string>();
            List<string> listLocal = new List<string>();
		
        	while (!reader.EndOfStream)
        	{
            	var line = reader.ReadLine();
            	var values = line.Split(',');

            	listId.Add(values[0]);
            	listPontos1.Add(values[1]);
				listAtributo1.Add(values[2]);
				listPontos2.Add(values[3]);
				listAtributo2.Add(values[4]);
                listLocal.Add(values[5]);

                //print(values[0] + ", " + values[1] + ", " + values[2] + ", " + values[3] + ", " + values[4]);
        	}
		
			/************************************************
			******* CRIAÇÃO DO BARALHO DE CARTAS ************
			*************************************************/

			for(int i = 0; i < listId.Count; i++){
                //print("***CRIAÇÃO*** " + i + ". ID: " + listId[i] + " | Pontos1: " + listPontos1[i] + " | Pontos2: " + listPontos2[i] + " | Atributo1: " + listAtributo1[i] + " | Atributo2: " + listAtributo2[i]);
                Local loc;
                switch (listLocal[i]) {
                    case "casa" :
                        loc = new Local ("Casa");
                        break;
                    case "trabalho" :
                        loc = new Local ("Trabalho");
                        break;
                    case "hospital" :
                        loc = new Local ("Hospital");
                        break;
                    case "centro" :
                        loc = new Local ("Centro Comercial");
                        break;
                    case "ginasio" :
                        loc = new Local ("Ginásio");
                        break;
                    case "cafe" :
                        loc = new Local ("Café");
                        break;
                    default :
                        loc = null;
                        break;
                }
                Evento e = new Evento (int.Parse(listId[i]), int.Parse(listPontos1[i]), int.Parse(listPontos2[i]), listAtributo1[i], listAtributo2[i], objetosCarta[i], loc);
                baralho.Add(e);
               // print("BARALHO NA CRIACAO DO BARALHO::. ID: " + baralho[i].getId() + " | Pontos1: " + baralho[i].getP1() + " | Pontos2: " + baralho[i].getP2() + " | Atributo1: " + baralho[i].getA1() + " | Atributo2: " + baralho[i].getA2());
			}	
    	}
	}

	void distribuiCartas (Jogador j) {
        // int cartasMaoJ = 0;
        // for(int i = 0; i < baralho.Count; i++){
        //     //print("BARALHO [" + i + "]: " + baralho[i].getId());
        //     if(baralho[i].getId()!=null){
        //         j.addCarta(baralho[i]);
        //         baralho[i]=null;
        //         cartasMaoJ++;
        //     }
        //     if(cartasMaoJ==numCartas){
        //         print(j.cartasToString());
        //         return;
        //     }
        // }

        int i = 0;
		while (i < numCartas) {
			int abc = Random.Range(1,83);
    		if (!cartasNasMaos.Contains(abc)) {
    			cartasNasMaos[abc-1] = abc;
    			j.addCarta(baralho[abc-1]);
                baralho[abc-1] = nulo;
    			i++;
    		}
		}
	}

    void atualizaValores () {
        loucuraText.text = "Loucura: " + peao.getLoucura();
        saudeText.text = "Saúde: " + peao.getSaude();
        dinheiroText.text = "Dinheiro: " + peao.getDinheiro();
        trabalhoText.text = "Trabalho: " + peao.getTrabalho();
        amorText.text = "Vida Amorosa: " + peao.getAmor();
        socialText.text = "Vida Social: " + peao.getSocial();
    }

    IEnumerator introduzJogador (Jogador j) {

        while (!Input.GetKeyDown(KeyCode.RightArrow)){
            CanvasIntroduz.GetComponent<Canvas>().enabled = true;
            introduzText.text = "LOCAL: " + locais[localAtual].getNome() + "\r\nVEZ DO JOGADOR " + (jogadorAtual+1) + "!\r\n(prime -> para continuar)";
            //print("DENTRO DO WHILE");
            yield return null;
        }
        CanvasIntroduz.GetComponent<Canvas>().enabled = false;
        estadoAtual = Estado.MOSTRA_JOGO;

        mostraJogo(jogadores[jogadorAtual]);
        yield return null;
    }

    void mostraJogo (Jogador j) {
       // print(j.getNome() + " MOSTROU JOGO...");
        j.getObjetivo().getCanvas().GetComponent<Canvas>().enabled = true;
       // print("NUMERO DE CARTAS: " + numCartas);
        for (int i = 0; i < numCartas; i++) {

            // print("CARTAS DO BACANO: " + j.cartasToString());


            // print("CARTA " + (i+1) + ": " + j.getCartas()[i].getId());
            // print("POSIÇÃO CARTA " + (i+1) + ": " + posicoesCartas[i].position);
            j.getCartas()[i].getObjetoCarta().transform.position = posicoesCartas[i].position;
        }
        seleciona1Text.text = "[1]";
        seleciona2Text.text = "[2]";
        seleciona3Text.text = "[3]";
        seleciona4Text.text = "[4]";
        seleciona5Text.text = "[5]";
        estadoAtual = Estado.DECIDE_CARTA;
        StartCoroutine(decideCarta(jogadores[jogadorAtual]));
    }

    IEnumerator decideCarta (Jogador j) {
        bool decidiu = false;
        while (!decidiu) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                j.getCartas()[0].aplica(peao);
                memorias.Add(j.getCartas()[0]);
                decidiu = true;
                cartaEscolhida = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                j.getCartas()[1].aplica(peao);
                memorias.Add(j.getCartas()[1]);
                decidiu = true;
                cartaEscolhida = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                j.getCartas()[2].aplica(peao);
                memorias.Add(j.getCartas()[2]);
                decidiu = true;
                cartaEscolhida = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                j.getCartas()[3].aplica(peao);
                memorias.Add(j.getCartas()[3]);
                decidiu = true;
                cartaEscolhida = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5)) {
                j.getCartas()[4].aplica(peao);
                memorias.Add(j.getCartas()[4]);
                decidiu = true;
                cartaEscolhida = 4;
            }
            yield return null;
        }
        atualizaValores ();
        retiraCarta(jogadores[jogadorAtual], cartaEscolhida);
        //print("LOUCURA: " + peao.getLoucura() + "\r\nSAUDE: " + peao.getSaude() + "\r\nDINHEIRO: " + peao.getDinheiro() + "\r\nTRABALHO: " + peao.getTrabalho() + "\r\nAMOR: " + peao.getAmor() + "\r\nSOCIAL: " + peao.getSocial());
        estadoAtual = Estado.ESCONDE_JOGO;
        escondeJogo(j);
        yield return null;
    }

    void escondeJogo (Jogador j) {
        j.getObjetivo().getCanvas().GetComponent<Canvas>().enabled = false;
        for (int i = 0; i < numCartas; i++) {
            j.getCartas()[i].getObjetoCarta().transform.position = posOut.position;
        }
        seleciona1Text.text = "";
        seleciona2Text.text = "";
        seleciona3Text.text = "";
        seleciona4Text.text = "";
        seleciona5Text.text = "";
        estadoAtual = Estado.MUDA_DE_JOGADOR;
        mudaJogador();
    }

    void mudaJogador () {
        if (jogadorAtual == jogadores.Count-1) {
            jogadorAtual = 0;
            estadoAtual = Estado.MUDA_DE_LOCAL;
            mudaLocal();
        }
        else {
            jogadorAtual++;
        }
        //print("MUDOU DE JOGADOR: ANTES: " + (jogadorAtual-1) + " DEPOIS: " + jogadorAtual);
        if (peao.getLoucura() == 100) {
            estadoAtual = Estado.FINAL;
            introduzText.text = "";
            CanvasIntroduz.GetComponent<Canvas>().enabled = false;
            StartCoroutine(fim());
            return;
        }
        StartCoroutine(introduzJogador(jogadores[jogadorAtual]));
    }

    void retiraCarta (Jogador j, int index) {

        memorias.Add(j.getCartas()[index]);
        //print(j.getNome() + " - CARTAS ANTES DE SER RETIRADO: " + j.cartasToString());
        for (int i = 0; i < baralho.Count; i++) {
            if (baralho[i].getId() != -1){       
                j.getCartas()[index].getObjetoCarta().transform.position = posOut.position;       
                j.getCartas()[index] = baralho[i];
                baralho[i] = nulo; 
                //print(j.getNome() + " - CARTAS DEPOIS: " + j.cartasToString());
                return;
            }
        }

        // Se chegou fora do for eh pk nao ha cartas no baralho

        List <Evento> temp = new List <Evento> ();
        temp = memorias;
        memorias = new List<Evento>();
        baralho = temp;

        baralho = ShuffleList(baralho);

        j.getCartas()[index].getObjetoCarta().transform.position = posOut.position;       
        j.getCartas()[index] = baralho[0];
        baralho[0] = nulo; 
    }

    private List<E> ShuffleList<E>(List<E> inputList){
         List<E> randomList = new List<E>();

         int randomIndex = 0;
         while (inputList.Count > 0)
         {
              randomIndex = Random.Range(0, inputList.Count); //Choose a random object in the list
              randomList.Add(inputList[randomIndex]); //add it to the new, random list
              inputList.RemoveAt(randomIndex); //remove to avoid duplicates
         }

         return randomList; //return the new random list
    }

    void mudaLocal () {
        //print(locais[localAtual].getNome());
        switch (localAtual) {
            case 0:
                peao.setLocal(locais[localAtual+1]);
                localAtual++;
                //MOVIMENTO DA CAMARA
                cam.transform.position = trabalhoPos.position;
                break;
            case 1:
                peao.setLocal(locais[localAtual+1]);
                localAtual++;
                cam.transform.position = hospitalPos.position;
                break;
            case 2:
                peao.setLocal(locais[localAtual+1]);
                localAtual++;
                cam.transform.position = centroPos.position;
                break;
            case 3:
                peao.setLocal(locais[localAtual+1]);
                localAtual++;
                cam.transform.position = ginasioPos.position;
                break;
            case 4:
                peao.setLocal(locais[localAtual+1]);
                localAtual++;
                cam.transform.position = cafePos.position;
                break;
            case 5:
                peao.setLocal(locais[0]);
                localAtual = 0;
                cam.transform.position = casaPos.position;
                peao.atualizaLoucura(10);
                peao.atualizaDinheiro(10); 
                atualizaValores();
                break;
            default:
                break;
        }
    }

    IEnumerator fim () {
        disableCanvas ();
        loucuraText.text = "";
        saudeText.text = "";
        dinheiroText.text = "";
        trabalhoText.text = "";
        amorText.text = "";
        socialText.text = "";
        introduzText.text = "";
        CanvasIntroduz.GetComponent<Canvas>().enabled = false;
        CanvasFinal.GetComponent<Canvas>().enabled = true;
        bool haVencedor = false;
        Jogador v = new Jogador("");
        int numeroVencedores = 0;
        for (int i = 0; i < numJogadores; i++) {
            if(verificaVencedor(jogadores[i])) {
                finalText.text = "Parabéns, " + "\r\n" + jogadores[i].getNome() + "! Objetivo: " + jogadores[i].getObjetivo().getNome();
                v = jogadores[i];
                haVencedor = true;
                numeroVencedores++;
            }
        }
        if (numeroVencedores == 1) {
            v.getObjetivo().getCanvas().GetComponent<Canvas>().enabled = true;
        }
        if (!haVencedor) {
            finalText.text = "Ninguém ganhou...\r\nMas todos ficaram loucos!";
        }
        yield return null;
    }

    bool verificaVencedor (Jogador j) {
        switch (j.getObjetivo().getNome()) {
            case "Saudável" :
                if (peao.getSaude() >= 80) return true;
                break;
            case "Doente" :
                if (peao.getSaude() <= 20) return true;
                break;
            case "Rico" :
                if (peao.getDinheiro() >= 80) return true;
                break;
            case "Pobre" :
                if (peao.getDinheiro() <= 20) return true;
                break;
            case "Trabalhador" :
                if (peao.getTrabalho() >= 80) return true;
                break;
            case "Desleixado" :
                if (peao.getTrabalho() <= 20) return true;
                break;
            case "Amoroso" :
                if (peao.getAmor() >= 80) return true;
                break;
            case "Safado" :
                if (peao.getAmor() <= 20) return true;
                break;
            case "Amigo" :
                if (peao.getSocial() >= 80) return true;
                break;
            case "Inimigo" :
                if (peao.getSocial() <= 20) return true;
                break;
            default:
                return false;
                break;
        }
        return false;
    }

}
