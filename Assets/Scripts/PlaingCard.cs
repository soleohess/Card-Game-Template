using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayingCard : MonoBehaviour // This sprite draws card images.
{
    public Card_data data;

    public int suit;
    public int number;
    public Sprite sprite;
    
    public TextMeshProUGUI numberText;
    public Image spriteImage;
        

    // Start is called before the first frame update
    void Start()
    {
        number = data.number;
        numberText.text = number.ToString();
        spriteImage.sprite = sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}