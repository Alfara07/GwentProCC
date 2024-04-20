using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool[] VWheather = new bool[3];
    public GameObject[] WheatherPositions = new GameObject[3];
    public GameObject[] campo = new GameObject[33];
    public GameObject Dragon, Win1, Win2;
    public int camposASig = 0;
    public bool Jugada,player1Round,player2Round,End_ROUND = false;
    public int poder1, poder2, ronda1, ronda2;
    public int player = 1;
    public Deck deck1, deck2;
    public TextMeshProUGUI power1,power2,Ronda1,Ronda2;
    
    public GameObject Decoy = null;
    public int Decoy_Pos;

    public bool jug1, jug2 = true;
    private void Update()
    {
        Powers();
        End_Round();
        End_Game();
    }

    //Funcion para para contar los poderes en el campo
    public void Powers()
    {
        if (player == 1)
        {
            power1.text = "Power: " + poder1.ToString();
            Ronda1.text = ronda1.ToString();
            Ronda2.text = ronda2.ToString();
            power2.text = "Power: " + poder2.ToString();
        }
        if (player == 2)
        {
            power1.text = "Power: " + poder2.ToString();
            power2.text = "Power: " + poder1.ToString();
            Ronda1.text = ronda2.ToString();
            Ronda2.text = ronda1.ToString();
        }
    }

    public void End_Game()
    {
        if (ronda1 == 2 && ronda2 != 2)
        {
            Dragon.SetActive(true);
            Win1.SetActive(true);

        }
        if (ronda2 == 2 && ronda1 != 2)
        {
            Dragon.SetActive(true);
            Win2.SetActive(true);

        }
    }
    //Funcion para determinar quien gana la ronda y hacer el conteo de rondas

    public void End_Round()
    {
        if(player1Round && player2Round)
        {
            End_ROUND = true;
            if(poder1 < poder2)
            {
                ronda2 += 1;
                
            }

            if (poder1 > poder2)
            {
                ronda1 += 1;               
            }
            if(poder1 == poder2)
            {
                ronda1++;
                ronda2++;
            }
            player1Round = false;
            player2Round = false;
            poder1 = 0;
            poder2 = 0;
            deck1.MASTER(2);
            deck2.MASTER(2);

            for(int i =0; i < 33; i++)
            {
                
                    Destroy(campo[i]);
                    campo[i] = null;
                    camposASig = 0;
                

            }
        }
    }
}
