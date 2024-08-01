using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private const int MaxCurrentCardSize = 5;

    //  �÷��̾ ����� �� �ִ� ī�� �迭
    [SerializeField] public Image[] m_CurrentCards = new Image[MaxCurrentCardSize];

    //  �÷��� �� �� ���Ǵ� ��ü ī�� ����
    [SerializeField] public List<Sprite> m_TotalCardList = null;

    //  ���� ���ӿ��� ���� ī�� ����Ʈ
    public readonly List<int> m_UsedCards = new List<int>();
    public readonly List<int> CardsNum = new List<int>();

    //ī�� 5���� �̴� �Լ�
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