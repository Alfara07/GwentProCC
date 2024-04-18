using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject[] Decks = new GameObject[32];
    public GameObject[] Hands = new GameObject[10];
    public GameObject[] Positions = new GameObject[10];
    public GameObject[] InvocationPositions = new GameObject[12];
    public bool[] VInvocation = new bool[12];
    public GameObject[] IncreasedPositions = new GameObject[3];
    public bool[] VIncreased = new bool[3];
    public GameManager Manager;

    private int Position = 0;

    //Metodo para llevar las cartas del mazo a la mano.
    private void MASTER(int cant)
    {
        for (int x = 0; x < cant; x++)
        {
            for (int y = 0; y < Hands.Length; y++)
            {
                if (Hands[y] == null)
                {
                    Hands[y] = GameObject.Instantiate(Decks[Position], Positions[y].transform.position, Positions[y].transform.rotation); //Spawnea las cartas en la mano.
                    Hands[y].transform.localScale = Positions[y].transform.localScale;
                    Position++;
                    break;
                }
            }

        }
    }

    private void Start()
    {
        Shuffle();
        MASTER(10);
    }

    //Metodo para barajear las cartas de forma aleatoria.
    private void Shuffle()
    {
        for (int x = 0; x < Decks.Length; x++)
        {
            GameObject card = Decks[x];
            int r = Random.Range(0, Decks.Length);
            Decks[x] = Decks[r];
            Decks[r] = card;
        }
    }

    //Metodo para invocar las cartas en el campo
    public bool Invocar(GameObject card)
    {
        if (!card.GetComponent<CardsProperties>().invocado)
        {
            //Invocacion de cartas unidad
            if (card.GetComponent<CardsProperties>().Type == "Gold Unit" || card.GetComponent<CardsProperties>().Type == "Silver Unit")
            {
                if (card.GetComponent<AttackCardProperties>().TypeAttack == "Melee") //Verifica si es tipo melee
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (!VInvocation[i])
                        {
                            card.transform.position = InvocationPositions[i].transform.position;
                            VInvocation[i] = true;
                            return true;
                        }
                    }
                }

                if (card.GetComponent<AttackCardProperties>().TypeAttack == "Range") //Verifica si es tipo range
                {
                    for (int i = 4; i < 8; i++)
                    {
                        if (!VInvocation[i])
                        {
                            card.transform.position = InvocationPositions[i].transform.position;
                            VInvocation[i] = true;
                            return true;
                        }
                    }
                }
                if (card.GetComponent<AttackCardProperties>().TypeAttack == "Siege") // Verifica si es tipo Siege
                {
                    for (int i = 8; i < 12; i++)
                    {
                        if (!VInvocation[i])
                        {
                            card.transform.position = InvocationPositions[i].transform.position;
                            VInvocation[i] = true;
                            return true;
                        }
                    }
                }
            }
            //Verifcar Si es carta aumento
            if(card.GetComponent<CardsProperties>().Type == "Increased")
            {
                if(card.GetComponent<IncreaseCardProperties>().affected == "Melee" && !VIncreased[0]) //Verifica si es melee
                {
                    card.transform.position = IncreasedPositions[0].transform.position;
                }
                if (card.GetComponent<IncreaseCardProperties>().affected == "Range" && !VIncreased[1]) //Verifica si es range
                {
                    card.transform.position = IncreasedPositions[1].transform.position;
                }
                if (card.GetComponent<IncreaseCardProperties>().affected == "Siege" && !VIncreased[2]) //Verifica si es siege
                {
                    card.transform.position = IncreasedPositions[2].transform.position;
                }
            }

            //verificar si es carta clima
            if(card.GetComponent<CardsProperties>().Type == "Weather")
            {
                if(card.GetComponent<WeatherCardProperties>().affected == "Melee" && !Manager.VWheather[0]) //Verifica si es melee
                {
                    Manager.VWheather[0] = true;//Accede a las posiciones verificadas de clima del manager y convierte en true
                    card.transform.position = Manager.WheatherPositions[0].transform.position;//Accede a las posiciones clima del manager y mueve la carta
                }
                if (card.GetComponent<WeatherCardProperties>().affected == "Range" && !Manager.VWheather[1]) //Verifica si es melee
                {
                    Manager.VWheather[1] = true;//Accede a las posiciones verificadas de clima del manager y convierte en true
                    card.transform.position = Manager.WheatherPositions[1].transform.position; //Accede a las posiciones clima del manager y mueve la carta
                }
                if (card.GetComponent<WeatherCardProperties>().affected == "Siege" && !Manager.VWheather[2]) //Verifica
                {
                    Manager.VWheather[2] = true;//Accede a las posiciones verificadas de clima del manager y convierte en true
                    card.transform.position = Manager.WheatherPositions[2].transform.position;//Accede a las posiciones clima del manager y mueve la carta
                }
            }
        }
        return false;
    }
}