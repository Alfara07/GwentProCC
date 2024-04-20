using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCard : MonoBehaviour
{
    public RawImage[] Image = new RawImage[10];
    public GameManager GameManager;
    public GameObject button;
    private bool inicio = false;
    int cambio = 0;
    private void OnMouseDown()
    {
        if(!inicio)
        {
            GameManager.deck2.MASTER(10);
            GameManager.deck1.MASTER(10);
            for(int i = 0; i < 10; i++)
            {
                Image[i].texture = GameManager.deck1.Hands[i].GetComponent<SpriteRenderer>().sprite.texture;
                Image[i].transform.localScale =  new Vector2(1.5f,2);
            }
            button.transform.localScale = Vector3.one;
            inicio = true;
        }
    }

    public void Cambio()
    {
     if(GameManager.player == 2 && GameManager.jug2)
        {
            for(int i = 0; i<Image.Length;i++)
            {
                Image[i].texture = GameManager.deck2.Hands[i].GetComponent<SpriteRenderer>().sprite.texture;
                Image[i].transform.localScale = new Vector2(1.5f, 2);
            }
            button.transform.localScale = Vector3.one;
            
        }
    }

    public void End(int num, Deck deck)
    {
        Destroy(deck.Hands[num]);
        deck.Hands[num] = null;
        deck.MASTER(1);
        Image[num].transform.localScale = Vector3.zero;
        cambio++;
        if(cambio == 2)
        {
            Se_Acabo();
        }
    }

    public void Se_Acabo()
    {
        for(int i = 0; i < Image.Length;i++)
        {
            if(Image[i] != null)
            {
                Image[i].transform.localScale = Vector3.zero;
            }
        }
        button.transform.localScale = Vector3.zero;

        if(GameManager.player == 1)
        {
            GameManager.jug1 = false;
        }
        if (GameManager.player == 2)
        {
            GameManager.jug2 = false;
        }
        GameManager.Jugada = false;
        cambio = 0;
    }
}
