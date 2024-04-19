using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeWeather : MonoBehaviour
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
            for (int i = 0; i < gameManager.deck2.Hands.Length; i++)
            {
                if (gameManager.deck2.Hands[i]!=null)
                {
                    if (gameManager.deck2.Hands[i].GetComponent<CardsProperties>().Type == "Weather")
                    {
                        gameManager.Jugada = false;
                        if (gameManager.deck2.Invocar(gameManager.deck2.Hands[i]))
                        {
                            break;
                        }
                    }
                }
                
            }
            gameManager.Jugada = true;
            activate = true;
        }
    }
}
