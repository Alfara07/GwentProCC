using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPower : MonoBehaviour
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
            int cantidad = 1;
            for(int i = 0; i < gameManager.campo.Length;i++)
            {
                if (gameManager.campo[i]!= null)
                {
                    if (gameManager.campo[i].GetComponent<CardsProperties>().Name == GetComponent<CardsProperties>().Name)
                    {
                        if (gameManager.campo[i] != gameObject)
                        {
                            gameManager.poder1 -= gameManager.campo[i].GetComponent<AttackCardProperties>().Damage;
                            gameManager.campo[i].GetComponent<AttackCardProperties>().Damage += GetComponent<AttackCardProperties>().Damage;
                            cantidad++;
                            gameManager.poder1 += gameManager.campo[i].GetComponent<AttackCardProperties>().Damage;
                        }
                    }
                }
            }
            gameManager.poder1 -= GetComponent<AttackCardProperties>().Damage;
            int s = GetComponent<AttackCardProperties>().Damage *= cantidad;
            gameManager.poder1 += s;
            activate = true;
        }
    }
}
