using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    [Header("Jugador")]
    private int puntosJugador = 0; // Puntos del jugador
    private Carta[] cartasJugador; // Cartas del jugador
    [HideInInspector]public bool terminado = false; // Determina si el jugador termino su mano actual

    [Header("Rival")]
    private RivalManager rival; // Rival actual
    private int puntosRival = 0; // Puntos del rival
    private Carta[] cartasRival; // Cartas del rival

    [Header("General")]
    public int ronda = 1; // Numero de ronda actual
    public int ptsParaGanar = 30; // Puntos necesarios para ganar
    public bool mano; // Mano actual (true -> Jugador || false -> Rival)
    private int truco = 0;
    private int envido = 0;

    private void Awake()
    {
        if(game == null)
        {
            game = this;
        }else if(game != this)
        {
            Destroy(this);
            Debug.LogError("No debe haber mas de un Game Manager");
        }
    }

    private void Start()
    {
        StartCoroutine(JugarRonda());
    }

    public void SetRival(RivalManager rival)
    {
        this.rival = rival;
    }

    IEnumerator JugarRonda()
    {
        // cartasJugador, cartasRival = ReglasTruco.RepartirCartas();
        ronda = 1;
        truco = 0;
        envido = 0;

        while(ronda <= 3)
        {
            UIManager.ui.SetRonda(ronda);

            terminado = false;
            Jugar();
            while (mano && !terminado) yield return new WaitForEndOfFrame();

            mano = !mano;

            Jugar();
            while (mano && !terminado) yield return new WaitForEndOfFrame();

            // mano = ReglasTruco.GanadorRonda(cartasJugador, cartasRival, ronda);

            ronda++;
        }

        SetUI();
    }

    void SetUI()
    {
        UIManager.ui.SetPuntos(puntosJugador, puntosRival);
        UIManager.ui.SetRonda(ronda);
    }

    void Jugar()
    {
        if (mano)
        {
            UIManager.ui.PlayerUI(ronda == 1);
        }
        else
        {
            if (rival != null) rival.Jugar();
        }
    }

    public void FinTurnoJugador()
    {
        terminado = true;
    }

    public void TrucoJugador()
    {
        truco++;
        if (rival != null) rival.Truco(truco);
    }

    public void EnvidoJugador()
    {
        envido++;
        if (rival != null) rival.Envido(envido);
    }

}
