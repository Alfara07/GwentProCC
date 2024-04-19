using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMinPower : MonoBehaviour
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
            int poder = 100;
            int pos = 0;
            GameObject card = null;
            for(int i = 0; i < gameManager.campo.Length; i++)
            {
                if (gameManager.campo[i] != null)
                {
                    if (gameManager.campo[i].GetComponent<CardsProperties>().Faction == "Classics")
                    {
                        if (gameManager.campo[i].GetComponent<CardsProperties>().Type == "Silver Unit")
                        {
                            if (gameManager.campo[i].GetComponent<AttackCardProperties>().Damage < poder)
                            {
                                poder = gameManager.campo[i].GetComponent<AttackCardProperties>().Damage;
                                card = gameManager.campo[i];
                                pos = i;
                            }
                        }
                    }
                }
            }
            if(card != null)
            {
                Destroy(card);
                gameManager.campo[pos] = null;
                gameManager.poder1 -= poder;
            }
            activate = true;
        }
    }
}
