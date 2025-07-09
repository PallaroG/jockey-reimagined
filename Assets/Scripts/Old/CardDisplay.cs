using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using MesalongaStudios;

public class CardDisplay : MonoBehaviour
{
    
    public Card cardData;
    public Image cardImage;
    public TMP_Text nameText;
    public Color cardColor;

    void Start()
    {
    	UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {
    	//nameText.text = cardData.cardName;
    	

    }
}
