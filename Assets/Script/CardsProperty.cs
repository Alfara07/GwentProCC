using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsProperty : MonoBehaviour
{
    public string Name;
    public string Faction;
    public string Type;

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
}
