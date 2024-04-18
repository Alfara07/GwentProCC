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
            if (card.GetComponent<CardsProperties>().Type == "Gold Unit" || card.GetComponent<CardsProperties>().Type == "Silver Unit")
            {
                if (card.GetComponent<AttackCardProperties>().TypeAttack == "Melee")
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

                if (card.GetComponent<AttackCardProperties>().TypeAttack == "Range")
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
                if (card.GetComponent<AttackCardProperties>().TypeAttack == "Siege")
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
        }
        return false;
    }
}