using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardModule : MonoBehaviour
{
    Battle battle;

    public static int MaxChangeCard = 2;
    public static int CurrentChangeCard = 0;

    // Start is called before the first frame update
    void Start()
    {
        battle = GameObject.Find("CardsDraw").GetComponent<Battle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCard(int CardNumber)
    {
        if (CurrentChangeCard < MaxChangeCard)
        {
            int index = Random.Range(0, battle.m_TotalCardList.Count);

            while (battle.m_UsedCards.Exists(x => x == index))
            {
                index = Random.Range(0, battle.m_TotalCardList.Count);
            }

            battle.m_CurrentCards[CardNumber].sprite = GetSprite(battle.m_TotalCardList[index].texture);
            battle.m_UsedCards.Add(index);
            battle.CardsNum[CardNumber] = index;

            Debug.Log("Done");

            CurrentChangeCard++;
        }
    }

    public static Sprite GetSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public void Card1Click()
    {
        ChangeCard(0);
    }
    public void Card2Click()
    {
        ChangeCard(1);
    }
    public void Card3Click()
    {
        ChangeCard(2);
    }
    public void Card4Click()
    {
        ChangeCard(3);
    }
    public void Card5Click()
    {
        ChangeCard(4);
    }
}