using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayingCard : MonoBehaviour // This sprite draws card images.
{
    public Card_data data;

    public int suit;
    public string symbol;
    public Sprite sprite;
    
    public TextMeshProUGUI numberText;
    public Image spriteImage;
        

    // Start is called before the first frame update
    void Start()
    {
        symbol = data.symbol;
        numberText.text = symbol;
        spriteImage.sprite = sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}