using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsProperties : MonoBehaviour
{
    public string Name;
    public string Faction;
    public string Type;
    //Metodo para comprobar si se ha invocado la carta
    public bool invocado = false;

    //Localizando el Big Card
    private SpriteRenderer BigCard;

    private void Start()
    {
        BigCard = GameObject.FindGameObjectWithTag("BigCard").GetComponent<SpriteRenderer>();
    }

    //Metodos para mostrar y dejar de mostrar las cartas en grande
    private void OnMouseEnter()
    {
        BigCard.sprite=GetComponent<SpriteRenderer>().sprite;
    }

    private void OnMouseExit()
    {
        BigCard.sprite=null;
    }

    //Evento que llama al metodo de invocacion
    private void OnMouseDown()
    {
        if(GameObject.FindGameObjectWithTag(Faction).GetComponent<Deck>().Invocar(gameObject))
        {
            invocado = true;
        }
    }
}