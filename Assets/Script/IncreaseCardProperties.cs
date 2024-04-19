using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCardProperties : MonoBehaviour
{
    public string affected;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Admin").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (GetComponent<CardsProperties>().invocado)
        {
            Increment();
        }
    }

    //Metodo para activar efecto de incremento
    public void Increment()
    {
        for (int i = 0; i < gameManager.campo.Length; i++)
        {
            if (gameManager.campo[i] != null)
            {
                if (gameManager.campo[i].GetComponent<CardsProperties>().Type == "Silver Unit") //Verifica si la carta es plata
                {
                    if (!gameManager.campo[i].GetComponent<AttackCardProperties>().afected_Aum) //Verifica si ya fue afectada
                    {
                        if (affected == gameManager.campo[i].GetComponent<AttackCardProperties>().TypeAttack)
                        {
                            if (gameManager.campo[i].GetComponent<CardsProperties>().Faction == GetComponent<CardsProperties>().Faction)
                            {
                                gameManager.poder1 += 3;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().Damage += 3;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().afected_Aum = true;
                            }                            
                        }
                    }
                }
            }

        }
    }

    public void Decrement()
    {
        for (int i = 0; i < gameManager.campo.Length; i++)
        {
            if (gameManager.campo[i] != null)
            {
                if (gameManager.campo[i].GetComponent<CardsProperties>().Type == "Silver Unit")
                {
                    if (gameManager.campo[i].GetComponent<AttackCardProperties>().afected_Aum)
                    {
                        if (affected == gameManager.campo[i].GetComponent<AttackCardProperties>().TypeAttack)
                        {
                            if (gameManager.campo[i].GetComponent<CardsProperties>().Faction == GetComponent<CardsProperties>().Faction)
                            {
                                gameManager.poder1 -= 3;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().Damage -= 3;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().afected_Aum = false;
                            }
                        }
                    }
                }
            }

        }
    }
}
