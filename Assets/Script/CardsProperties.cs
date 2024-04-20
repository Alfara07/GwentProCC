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
    private GameManager manager;
    private void Start()
    {
        BigCard = GameObject.FindGameObjectWithTag("BigCard").GetComponent<RawImage>();
        Description = GameObject.FindGameObjectWithTag("TextD").GetComponent<TextMeshProUGUI>();
        Edit = GameObject.FindGameObjectWithTag("Edit");
        BigCard.transform.localScale = Vector3.zero;
        Edit.transform.localScale = Vector3.zero;
        manager = GameObject.FindGameObjectWithTag("Admin").GetComponent<GameManager>();
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
        bool se_toco = false;
        if(GameObject.FindGameObjectWithTag(Faction).GetComponent<Deck>().Invocar(gameObject))
        {
            invocado = true;
            se_toco = true;

        }
        if(invocado && manager.Decoy != null && !se_toco && Type != "Decoy" && !manager.Jugada)
        {
            if (Type == "Silver Unit" || Type == "Gold Unit")
            {
                if (Faction == manager.Decoy.GetComponent<CardsProperties>().Faction)
                {
                    GameObject decoy = manager.Decoy;
                    decoy.transform.position = gameObject.transform.position;
                    if (Faction == "Classics")
                    {
                        manager.poder1 -= gameObject.GetComponent<AttackCardProperties>().Damage;
                        gameObject.transform.position = manager.deck1.Positions[manager.Decoy_Pos].transform.position;
                    }
                    if (Faction == "Cartoons")
                    {
                        manager.poder2 -= gameObject.GetComponent<AttackCardProperties>().Damage;
                        gameObject.transform.position = manager.deck2.Positions[manager.Decoy_Pos].transform.position;

                    }
                    invocado = false;
                    manager.Jugada = true;
                }
                
            }
        }
    }
}