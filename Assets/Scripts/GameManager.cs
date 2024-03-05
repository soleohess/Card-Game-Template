using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<PlayingCard> deck = new List<PlayingCard>();
    public List<PlayingCard> player_deck = new List<PlayingCard>();
    public List<PlayingCard> ai_deck = new List<PlayingCard>();
    public List<PlayingCard> player_hand = new List<PlayingCard>();
    public List<PlayingCard> ai_hand = new List<PlayingCard>();
    public List<PlayingCard> discard_pile = new List<PlayingCard>();

    public bool playerTurnNext;
    public bool AITurnNext;
    public int remainingTax;
    public bool addToPlayerDeckNext;
    public bool addToAIDeckNext;
    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
// Deal 26 cards to you and 26 to AI
// You reveal a card.
// AI reveals a card.
// Repeat revealing until a face is revealed.
// Pay taxes
// Put middle cards in stack
/// Repeat until win.

    void Deal()
    {
        // Deal 26 cards to each player.
    }

    void Action() // Modes game can be in: Player playing card for turn, player paying taxes, AI playing card for turn, AI paying taxes, put stack in player deck, put stack in AI deck.
    {
        if (playerTurnNext && remainingTax == 0) //No face cards flipped yet, player taking their turn
        {
            // Flip card
            playerTurnNext = false;
            AITurnNext = true;
            // if face card flipped
            //{
                // remainingTax = something;
            //}
        }

        if (AITurnNext && remainingTax == 0) //No face cards flipped yet, AI taking their turn
        {
            // Flip card
            AITurnNext = false; 
            playerTurnNext = true;
            // if face card flipped
            //{
            // remainingTax = something;
            //}
        }

        if (playerTurnNext && remainingTax > 0) // Player paying taxes
        {
            //Flip card
            remainingTax -= 1;
            if (remainingTax == 0) // If we're done paying taxes
            {
                playerTurnNext = false;
                addToAIDeckNext = true;
            } // If not done paying taxes, remainingTax is still positive and playerTurnNext is still true, so we will pay taxes next turn.
        }
        
        if (AITurnNext && remainingTax > 0) // AI paying taxes
        {
            //Flip card
            remainingTax -= 1;
            if (remainingTax == 0) // If we're done paying taxes
            {
                AITurnNext = false;
                addToPlayerDeckNext = true;
            } // If not done paying taxes, remainingTax is still positive and AITurnNext is still true, so we will pay taxes next turn.
        }

        if (addToPlayerDeckNext)
        {
            // add cards to player's deck
            addToPlayerDeckNext = false;
            playerTurnNext = true;
        }
        if (addToAIDeckNext)
        {
            // add cards to AI's deck
            addToAIDeckNext = false;
            AITurnNext = true;
        }

        
    }
//    void Shuffle()
//    {
    
//    }

//    void AI_Turn()
//    {

//    }



    
}
