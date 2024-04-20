using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soltar_Carta : MonoBehaviour
{
    public DrawCard game;
    public int num;
    public GameManager manager;
    public void Activar()
    {
        if(manager.player == 1)
        {
            game.End(num, manager.deck1);
        }
        if (manager.player == 2)
        {
            game.End(num, manager.deck2);
        }
    }
}
