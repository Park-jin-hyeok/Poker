using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  코드를 작성할 땐 항상 코드 종속성을 잘 지키자!
//  게임 매니저는 게임을 매니징 할 뿐 전투라던가 다른 컴포넌트는 다른 쪽에서!
//  전투면 전투 스크립트만, 캐릭터면 캐릭터 스크립트만

//  이제 이 게임매니저는 씬이 넘어가도 절대 부서지지 않는다!
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
        //  GameObject.Find 의 경우 쉽게 오브젝트를 찾을 수 있지만
        //  속도가 굉장히 느리고 같은 이름인 경우 최 상단(하이어라키 최상단 기준) 부터 가지고 오니 주의
        //  일반적으로 이런 경우 오브젝트를 캐싱(Cached) 하여 가지고 있다가 사용한다고 말함
        //  싱글톤 기억나니?
        //  객체가 없으면 생성해주고 있으면 기존에 있던걸 주는 단 하나만 존재하는 디자인 패턴
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