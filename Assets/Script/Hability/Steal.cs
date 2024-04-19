using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : MonoBehaviour
{
    private GameManager gameManager;
    private bool activate = false;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Admin").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!activate && GetComponent<CardsProperties>().invocado)
        {
            gameManager.deck2.MASTER(1);
            activate = true;
        }
    }
}
