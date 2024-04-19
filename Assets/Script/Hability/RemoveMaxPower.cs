using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMaxPower : MonoBehaviour
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
            int poder = 0;
            int pos = 0;
            GameObject card = null;
            for (int i = 0; i < gameManager.campo.Length; i++)
            {
                if (gameManager.campo[i] != null)
                {
                    if (gameManager.campo[i].GetComponent<CardsProperties>().Type == "Silver Unit" && gameManager.campo[i] != gameObject)
                    {
                        if (gameManager.campo[i].GetComponent<AttackCardProperties>().Damage > poder)
                        {
                            poder = gameManager.campo[i].GetComponent<AttackCardProperties>().Damage;
                            card = gameManager.campo[i];
                            pos = i;
                        }
                    }
                }
            }
            if (card != null)
            {
                if(card.GetComponent<CardsProperties>().Faction == "Classics")
                {
                    gameManager.poder1 -= poder;

                }
                if (card.GetComponent<CardsProperties>().Faction == "Cartoons")
                {
                    gameManager.poder2 -= poder;

                }
                Destroy(card);
                gameManager.campo[pos] = null;

            }
            activate = true;
        }
    }
}

