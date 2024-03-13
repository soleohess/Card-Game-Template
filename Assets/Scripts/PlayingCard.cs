using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayingCard : MonoBehaviour // This sprite draws card images.
{
    public Card_data data;

    public TextMeshProUGUI Upper_Left_Symbol;
    public TextMeshProUGUI Middle_Symbol;
    public TextMeshProUGUI Lower_Right_Symbol;
    public Image Upper_Right_Sprite;
    public Image Lower_Left_Sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        if (data.value == 11)
        {
            Upper_Left_Symbol.text = "J";
            Middle_Symbol.text = "J";
            Lower_Right_Symbol.text = "J";
        }
        else if (data.value == 12)
        {
            Upper_Left_Symbol.text = "Q";
            Middle_Symbol.text = "Q";
            Lower_Right_Symbol.text = "Q";
        }
        else if (data.value == 13)
        {
            Upper_Left_Symbol.text = "K";
            Middle_Symbol.text = "K";
            Lower_Right_Symbol.text = "K";
        }
        else if (data.value == 14)
        {
            Upper_Left_Symbol.text = "A";
            Middle_Symbol.text = "A";
            Lower_Right_Symbol.text = "A";
        }
        else
        {
            Upper_Left_Symbol.text = data.value.ToString();
            Middle_Symbol.text = data.value.ToString();
            Lower_Right_Symbol.text = data.value.ToString();
        }
        
    Upper_Right_Sprite.sprite = data.suit;
    Lower_Left_Sprite.sprite = data.suit;
        
        

        //symbol = data.symbol;
        //numberText.text = symbol;
        //spriteImage.sprite = sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}