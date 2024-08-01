using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private const int MaxCurrentCardSize = 5;

    //  플레이어가 사용할 수 있는 카드 배열
    [SerializeField] public Image[] m_CurrentCards = new Image[MaxCurrentCardSize];

    //  플레이 할 때 사용되는 전체 카드 개수
    [SerializeField] public List<Sprite> m_TotalCardList = null;

    //  현재 게임에서 사용된 카드 리스트
    public readonly List<int> m_UsedCards = new List<int>();
    public readonly List<int> CardsNum = new List<int>();

    //카드 5장을 뽑는 함수
    public void DrawCard() 
    {
        m_UsedCards.Clear();
        CardsNum.Clear();

        for (int i = 0; i < 5; ++i)
        {
            int index = Random.Range(0, m_TotalCardList.Count);
            if (m_UsedCards.Exists(x => x == index))
            {
                i--;
                continue;
            }

            m_CurrentCards[i].sprite = GetSprite(m_TotalCardList[index].texture);

            CardsNum.Add(index);
            m_UsedCards.Add(index);
        }
    }

    public static Sprite GetSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    private void Start()
    {
        DrawCard();
    }
}