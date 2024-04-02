using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<PlayingCard> deck = new List<PlayingCard>();
    public List<PlayingCard> player_deck = new List<PlayingCard>();
    public List<PlayingCard> ai_deck = new List<PlayingCard>();
    public List<PlayingCard> discard_pile = new List<PlayingCard>();

    public bool playerTurnNext;
    public bool AITurnNext;
    public int remainingTax;
    public bool addToPlayerDeckNext;
    public bool addToAIDeckNext;

    private int rand;
    private PlayingCard card;
    public Transform _canvas;
    public Transform asdf;

    public GameObject AI_Back;
    public GameObject Player_Back;
    public GameObject AI_Grave;
    public GameObject Player_Grave;

    public PlayingCard oldCard;

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
    // Start is called before the first frame update, test comment
    void Start()
    {
        AI_Back = GameObject.FindGameObjectWithTag("AI_Back");
        Player_Back = GameObject.FindGameObjectWithTag("Player_Back");
        Deal();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Action();
        }
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
        while (deck.Count > 0)
        {
            rand = Random.Range(0, deck.Count);
            player_deck.Add(deck[rand]);
            card = deck[rand];
            deck.Remove(card);
            
            rand = Random.Range(0, deck.Count);
            ai_deck.Add(deck[rand]);
            card = deck[rand];
            deck.Remove(card);
        }
    }

    void Action() // 6 Modes game can be in: Player playing card for turn, player paying taxes, AI playing card for turn, AI paying taxes, put stack in player deck, put stack in AI deck.
    {
        if (playerTurnNext && remainingTax == 0) //No face cards flipped yet, player taking their turn
        {
            if (player_deck.Count > 0)
            {
                discard_pile.Add(player_deck[0]); // Put a duplicate of player's top card onto the front stack.
                card = player_deck[0];
                player_deck.Remove(card); //Delete the top card of the player's deck, as a copy of it went onto the main pile.

                playerTurnNext = false;
                AITurnNext = true;
                if (card.data.value > 10)
                {
                    Debug.Log("Face card flipped.");
                    remainingTax = card.data.value - 10;
                }
                Draw_Screen();
            } else {
                AI_Wins();
            }
        }

        else if (AITurnNext && remainingTax == 0) //No face cards flipped yet, AI taking their turn
        {
            if (ai_deck.Count > 0)
            {
                discard_pile.Add(ai_deck[0]); // Put a duplicate of AI's top card onto the front stack.
                card = ai_deck[0];
                ai_deck.Remove(card); //Delete the top card of the AI's deck, as a copy of it went onto the main pile.
            
                AITurnNext = false; 
                playerTurnNext = true;
                if (card.data.value > 10)
                {
                    Debug.Log("Face card flipped.");
                    remainingTax = card.data.value - 10;
                
                }
                Draw_Screen();
            } else {
                Player_Wins();
            }
        }

        else if (playerTurnNext && remainingTax > 0) // Player paying taxes
        {
            if (player_deck.Count > 0)
            {
                discard_pile.Add(player_deck[0]); // Put a duplicate of player's top card onto the front stack.
                card = player_deck[0];
                player_deck.Remove(card); //Delete the top card of the player's deck, as a copy of it went onto the main pile.

                if (card.data.value > 10) // If face card
                {
                Debug.Log("Face card flipped.");
                remainingTax = card.data.value - 10;
                AITurnNext = true;
                playerTurnNext = false;
                }
                else
                {
                    remainingTax -= 1;
                    if (remainingTax == 0) // If we're done paying taxes
                    {
                        playerTurnNext = false;
                        addToAIDeckNext = true;
                    } // If not done paying taxes, remainingTax is still positive and playerTurnNext is still true, so we will pay taxes next turn.
                }
                Draw_Screen();
            } else {
                AI_Wins();
            }

        }
        else if (AITurnNext && remainingTax > 0) // AI paying taxes
        {
            if (ai_deck.Count > 0)
            {
                discard_pile.Add(ai_deck[0]); // Put a duplicate of AI's top card onto the front stack.
                card = ai_deck[0];
                ai_deck.Remove(card); //Delete the top card of the player's deck, as a copy of it went onto the main pile.
            
                if (card.data.value > 10)
                {
                    Debug.Log("Face card flipped.");
                    remainingTax = card.data.value - 10;
                    playerTurnNext = true;
                    AITurnNext = false;
                }
                else
                {
                    remainingTax -= 1;
                    if (remainingTax == 0) // If we're done paying taxes
                    {
                        AITurnNext = false;
                        addToPlayerDeckNext = true; 
                    } // If not done paying taxes, remainingTax is still positive and AITurnNext is still true, so we will pay taxes next turn.
                }
                Draw_Screen();
            } else Player_Wins();
        }
        else if (addToPlayerDeckNext)
        {
            // add cards to player's deck

            while (discard_pile.Count > 0)
            {
                card = discard_pile[0];
                player_deck.Add(card);
                discard_pile.Remove(card);
            }


            addToPlayerDeckNext = false;
            playerTurnNext = true;
            Draw_Screen();
        }
        else if (addToAIDeckNext)
        {
            // add cards to AI's deck
            while (discard_pile.Count > 0)
            {
                card = discard_pile[0];
                ai_deck.Add(card);
                discard_pile.Remove(card);
            }

            addToAIDeckNext = false;
            AITurnNext = true;
            Draw_Screen();
        }

        
    }
    
    void Draw_Screen()
    {
        GameObject destroyedCard = GameObject.FindGameObjectWithTag("Card");
        Destroy(destroyedCard);
        
        oldCard = Instantiate(discard_pile[(discard_pile.Count - 1)], asdf.position, Quaternion.identity, _canvas);
        print(oldCard.gameObject.name);
        oldCard.gameObject.tag = "Card";
        //oldCard.transform.position = new Vector3(0, 0, 0);
        //Card current = Instantiate(discard_pile[(discard_pile.Count - 1)], new Vector3(0, 0, 0), quaternion.identity);
        if (player_deck.Count > 0)
        {
            Player_Back.SetActive(true);
        }
        else
        {
            Player_Back.SetActive(false);
        }

        if (ai_deck.Count > 0)
        {
            AI_Back.SetActive(true);
        }
        else
        {
            AI_Back.SetActive(false);
        }
    }
    
    void Player_Wins()
    {
        Debug.Log("Player_Wins");
        AI_Grave.SetActive(true);
    }

    void AI_Wins()
    {
        Debug.Log("AI_Wins");
        Player_Grave.SetActive(true);
    }
    
}