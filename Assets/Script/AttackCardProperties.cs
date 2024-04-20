using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackCardProperties : MonoBehaviour
{
    public int Damage;
    public string TypeAttack;
    public bool afected_clim = false;
    public bool afected_Aum = false;

    private void OnMouseEnter()
    {
        GameObject.FindGameObjectWithTag("TextD").GetComponent<TextMeshProUGUI>().text += "\nPoder: " + Damage.ToString();
    }
}
