using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CardsProperties : MonoBehaviour
{
    public string Name;
    public string Faction;
    public string Type;
    [TextArea(10,10)]public string leer;
    //Metodo para comprobar si se ha invocado la carta
    public bool invocado = false;

    //Localizando el Big Card
    private RawImage BigCard;
    private GameObject Edit;
    private TextMeshProUGUI Description;

    private void Start()
    {
        BigCard = GameObject.FindGameObjectWithTag("BigCard").GetComponent<RawImage>();
        Description = GameObject.FindGameObjectWithTag("TextD").GetComponent<TextMeshProUGUI>();
        Edit = GameObject.FindGameObjectWithTag("Edit");
        BigCard.transform.localScale = Vector3.zero;
        Edit.transform.localScale = Vector3.zero;
    }

    //Metodos para mostrar y dejar de mostrar las cartas en grande
    private void OnMouseEnter()
    {
        BigCard.texture=GetComponent<SpriteRenderer>().sprite.texture;
        BigCard.transform.localScale = Vector3.one;
        Edit.transform.localScale = Vector3.one;
        Description.text = leer;
    }

    private void OnMouseExit()
    {
        BigCard.texture=null;
        BigCard.transform.localScale = Vector3.zero;
        Edit.transform.localScale = Vector3.zero;
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