using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool[] VWheather = new bool[3];
    public GameObject[] WheatherPositions = new GameObject[3];
    public GameObject[] campo = new GameObject[33];
    public int camposASig = 0;
    public bool Jugada,player1Round,player2Round,End_ROUND = false;
    public int poder1, poder2, ronda1, ronda2;
    public int player = 1;
    public Deck deck1, deck2;
    public TextMeshProUGUI power1,power2,Ronda1,Ronda2;

    private void Update()
    {
        Powers();
        End_Round();
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

    //Funcion para determinar quien gana la ronda y hacer el conteo de rondas
    public void End_Round()
    {
        if(player1Round && player2Round)
        {
            string ganador = "Empate";
            End_ROUND = true;
            if(poder1 < poder2)
            {
                ganador = "Jugador 2 Win";
                ronda2 += 1;
            }

            if (poder1 > poder2)
            {
                ganador = "Jugador 1 Win";
                ronda1 += 1;
            }
            player1Round = false;
            player2Round = false;
            poder1 = 0;
            poder2 = 0;

            for(int i =0; i < 33; i++)
            {
                if (campo[i] != null)
                {
                    Destroy(campo[i]);
                    campo[i] = null;
                    camposASig = 0;
                }

            }
        }
    }
}
