using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RivalManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.game.SetRival(this);
    }

    public abstract void Jugar();

    public abstract void Envido(int envido);

    public abstract void Truco(int truco);
}
