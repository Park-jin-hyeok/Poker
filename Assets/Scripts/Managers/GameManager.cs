using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  �ڵ带 �ۼ��� �� �׻� �ڵ� ���Ӽ��� �� ��Ű��!
//  ���� �Ŵ����� ������ �Ŵ�¡ �� �� ��������� �ٸ� ������Ʈ�� �ٸ� �ʿ���!
//  ������ ���� ��ũ��Ʈ��, ĳ���͸� ĳ���� ��ũ��Ʈ��

//  ���� �� ���ӸŴ����� ���� �Ѿ�� ���� �μ����� �ʴ´�!
public class GameManager : MonoSingleton<GameManager>
{
    public readonly List<int> GetItem = new List<int>();

    public GameObject CoverImage;
    public GameObject HelpBox;
    public GameObject ShowButton;
    public GameObject HideButton;
    public GameObject Treasure;
    public GameObject OpenTreasure;
    public GameObject Item;

    public Battle battle;
    public Monster monster;

    public static int damage;

    void Start()
    {
        //  GameObject.Find �� ��� ���� ������Ʈ�� ã�� �� ������
        //  �ӵ��� ������ ������ ���� �̸��� ��� �� ���(���̾��Ű �ֻ�� ����) ���� ������ ���� ����
        //  �Ϲ������� �̷� ��� ������Ʈ�� ĳ��(Cached) �Ͽ� ������ �ִٰ� ����Ѵٰ� ����
        //  �̱��� ��ﳪ��?
        //  ��ü�� ������ �������ְ� ������ ������ �ִ��� �ִ� �� �ϳ��� �����ϴ� ������ ����
        Treasure.SetActive(false);

        battle = GameObject.Find("CardsDraw").GetComponent<Battle>();
        monster = GameObject.Find("Enemy1").GetComponent<Monster>();
    }

    public void OnClickStartButton()
    {
        CoverImage.SetActive(false);
    }

    public void OnClickEndButton()
    {
        Application.Quit();
    }

    public void OnClickBackButton()
    {
        CoverImage.SetActive(true);
    }

    public void OnClickShowButton()
    {
        HelpBox.SetActive(true);
        HideButton.SetActive(true);
        ShowButton.SetActive(false);
    }

    public void OnclickHideButton()
    {
        HelpBox.SetActive(false);
        HideButton.SetActive(false);
        ShowButton.SetActive(true);
    }

    public void TreasureOpen()
    {
        Treasure.SetActive(true);
        Item.SetActive(false);
    }

    public void ItemOpen()
    {
        OpenTreasure.SetActive(false);
        Item.SetActive(true);
    }

    public void ItemOff()
    {
        Treasure.SetActive(false);
        GetItem.Add(1);
    }

    public void Item1()
    {

    }

    void Update()
    {

    }
}