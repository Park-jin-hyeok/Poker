using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  �䷱ Ư�� ����Ʈ����� �� ü���� ����� �� ���� �̱��� ������ ���� �� ����
//  �ƴϸ� GameManager �� ��������� GameManager �� ���� ������ ���� ����
public class BattlePageManager : MonoSingleton<BattlePageManager>
{
    [SerializeField] private GameObject WinPage;     //  Hit image
    [SerializeField] private GameObject LosePage; //  Game over image

    //  �׻� ���Ӽ��� �� ������!
    //  �� �׷��ĸ�, ������Ʈ, ��ɺ� ���Ӽ��� �� ���絵 ���׿� ���İ�Ƽ �ڵ带 ������ �� �ִ�

    public bool ActiveWinPage { set => WinPage.SetActive(value); }
    public bool ActiveLosePage { set => LosePage.SetActive(value); }
}