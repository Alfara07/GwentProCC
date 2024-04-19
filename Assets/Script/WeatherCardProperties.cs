using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherCardProperties : MonoBehaviour
{
    public string affected;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Admin").GetComponent<GameManager>();
    }
    private void Update()
    {
        if(GetComponent<CardsProperties>().invocado)
        {
            Increment();
        }
    }

    //Activacion de efecto clima
    public void Increment()
    {
        for(int i = 0;i < gameManager.campo.Length;i++)
        {
            if (gameManager.campo[i] != null)
            {
                if (gameManager.campo[i].GetComponent<CardsProperties>().Type == "Silver Unit") //Verifica que sea plata
                {
                    if (!gameManager.campo[i].GetComponent<AttackCardProperties>().afected_clim) //Verifica  si ya fue afectada
                    {
                        if (affected == gameManager.campo[i].GetComponent<AttackCardProperties>().TypeAttack)
                        {
                            if (gameManager.campo[i].GetComponent<CardsProperties>().Faction == "Classics")
                            {
                                gameManager.poder1-=2;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().Damage-=2;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().afected_clim = true;
                            }
                            if (gameManager.campo[i].GetComponent<CardsProperties>().Faction == "Cartoons")
                            {
                                gameManager.poder2-=2;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().Damage-=2;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().afected_clim = true;
                            }
                        }
                    }
                }
            }
            
        }
    }

    //Metodo para eliminar efecto del clima
    public void Decrement()
    {
        for (int i = 0; i < gameManager.campo.Length; i++)
        {
            if(gameManager.campo[i] != null)
            {
                if (gameManager.campo[i].GetComponent<CardsProperties>().Type == "Silver Unit") //Verifica si la carta es plata
                {
                    if (gameManager.campo[i].GetComponent<AttackCardProperties>().afected_clim) //Verifica si esta afectada
                    {
                        if(affected == gameManager.campo[i].GetComponent<AttackCardProperties>().TypeAttack)
                        {
                            if (gameManager.campo[i].GetComponent<CardsProperties>().Faction == "Classics")
                            {
                                gameManager.poder1 += 2;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().Damage += 2;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().afected_clim = false;
                            }
                            if (gameManager.campo[i].GetComponent<CardsProperties>().Faction == "Cartoons")
                            {
                                gameManager.poder2+=2;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().Damage +=2;
                                gameManager.campo[i].GetComponent<AttackCardProperties>().afected_clim = false;
                            }
                        }
                        
                    }
                }
            }
           
        }
    }
}
