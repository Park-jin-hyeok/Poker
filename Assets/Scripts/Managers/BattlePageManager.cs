using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  요런 특수 이펙트라던가 씬 체인저 라던가 등등도 역시 싱글톤 관리가 편할 수 있음
//  아니면 GameManager 가 들고있으면 GameManager 를 통해 가져올 수도 있지
public class BattlePageManager : MonoSingleton<BattlePageManager>
{
    [SerializeField] private GameObject WinPage;     //  Hit image
    [SerializeField] private GameObject LosePage; //  Game over image

    //  항상 종속성을 잘 맞추자!
    //  왜 그러냐면, 컴포넌트, 기능별 종속성만 잘 맞춰도 버그와 스파게티 코드를 제거할 수 있다

    public bool ActiveWinPage { set => WinPage.SetActive(value); }
    public bool ActiveLosePage { set => LosePage.SetActive(value); }
}