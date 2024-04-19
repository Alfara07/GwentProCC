using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTurn : MonoBehaviour
{
    public GameObject cam1, cam2,BigCard;
    public bool camm1 = true;
    public bool camm2 = false;
    public GameManager gameManager;

    //Metodo de cambio de turno
    public void Change()
    {
        if(camm1)
        {
            
            if(!gameManager.Jugada)
            {
                gameManager.player1Round = true;
            }
            if(!gameManager.player2Round)
            {
                gameManager.player = 2;
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
            

        }

        if (camm2)
        {
            if (!gameManager.Jugada)
            {
                gameManager.player2Round = true;
            }
            if(!gameManager.player1Round)
            {
                cam2.SetActive(false);
                cam1.SetActive(true);
                gameManager.player = 1;
            }
           
        }
        if(!gameManager.player1Round && gameManager.player == 1|| !gameManager.player2Round && gameManager.player == 2)
        {
            camm1 = !camm1;
            camm2 = !camm2;
        }
       

        gameManager.Jugada = false;
    }
}
