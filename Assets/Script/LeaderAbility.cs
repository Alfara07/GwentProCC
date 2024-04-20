using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderAbility : MonoBehaviour
{
    public int habilidad;
    private bool activated = false;
    public GameManager manager;
    private void OnMouseDown()
    {       
        if(manager.player == 1 && habilidad == 1)
        {
            if(!activated)
            {
                for(int i = 0; i < manager.campo.Length; i++)
                {
                    if (manager.campo[i] != null)
                    {
                        if (manager.campo[i].GetComponent<CardsProperties>().Type == "Silver Unit")
                        {
                            if (manager.campo[i].GetComponent<AttackCardProperties>().TypeAttack == "Range")
                            {
                                Destroy(manager.campo[i]);
                                manager.campo[i] = null;
                            }
                        }
                    }
                }
                activated = true;
            }
        }

        if (manager.player == 2 && habilidad == 2)
        {
            if (!activated)
            {
                for (int i = 0; i < manager.campo.Length; i++)
                {
                    if (manager.campo[i] != null)
                    {
                        if (manager.campo[i].GetComponent<CardsProperties>().Type == "Silver Unit")
                        {
                            if (manager.campo[i].GetComponent<AttackCardProperties>().TypeAttack == "Melee")
                            {
                                Destroy(manager.campo[i]);
                                manager.campo[i] = null;
                            }
                        }
                    }
                }
                activated = true;
            }
        }

        manager.Jugada = true;
    }
}
