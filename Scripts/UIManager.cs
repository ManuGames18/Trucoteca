using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager ui;

    public TextMeshProUGUI puntosJugador;
    public TextMeshProUGUI puntosRival;
    public TextMeshProUGUI ronda;

    [Header("Player UI")]
    public GameObject playerUI;

    private void Awake()
    {
        if(ui == null)
        {
            ui = this;
        }else if(ui != this)
        {
            Destroy(this);
            Debug.LogError("No puede haber mas de un UI Manager");
        }
    }

    private void Start()
    {
        playerUI.SetActive(false);
    }

    /// <summary>
    /// Activa la interfaz del jugador para que seleccione si cantar algo
    /// </summary>
    /// <param name="envido">Activar el boton para el envido o no</param>
    public void PlayerUI(bool envido)
    {
        playerUI.SetActive(true);
        playerUI.transform.Find("BotonEnvido").gameObject.SetActive(envido);
    }

    public void SetPuntos(int jugador, int rival)
    {
        puntosJugador.text = "Jugador: " + jugador;
        puntosRival.text = "Rival: " + rival;
    }

    public void SetRonda(int r)
    {
        ronda.text = "Ronda: " + r;
    }
}
