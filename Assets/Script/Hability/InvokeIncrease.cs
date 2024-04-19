using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeIncrease : MonoBehaviour
{
    private GameManager gameManager;
    private bool activate = false;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Admin").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!activate && GetComponent<CardsProperties>().invocado)
        {
            for(int i = 0; i <  gameManager.deck1.Hands.Length; i++)
            {
                if (gameManager.deck1.Hands[i] != null)
                {
                    if (gameManager.deck1.Hands[i].GetComponent<CardsProperties>().Type == "Increased")
                    {
                        gameManager.Jugada = false;
                        if (gameManager.deck1.Invocar(gameManager.deck1.Hands[i]))
                        {
                            break;
                        }
                    }
                }
                
            }
            gameManager.Jugada=true;
            activate = true;
        }
    }
}
