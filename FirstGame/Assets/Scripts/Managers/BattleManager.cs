using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  namesapce 는 나중에 할 수 있으면 해보자
//  namespace 양식
//  MyCompany.Project Core Name.Component
//  회사 또는 내 이름.해당 프로젝트에서 중요 코어 등 대, 중분류 이름.현재 기능 이름
//  ex) kbkim.MyGame.Characters
//  ex) kbkim.MyGame.Characters.Controllers

//  이뇨속은 이제 전투를 담당한다!
//  단 전투 할 때만 사용하므로 영구적으로 사용하지 않을거임 (DontDestroyObject X)
//  작성할 때 게임오브젝트를 반드시 만들 필요는 없다 (핵심)
public class BattleManager:MonoSingleton<BattleManager>
{
    public Battle battle;
    public Monster monster;

    public int MaxChange = 1;
    public int CurrentChange = 0;


    public static int damage;

    void Start()
    {
        battle = GameObject.Find("CardsDraw").GetComponent<Battle>();
        monster = GameObject.Find("Enemy1").GetComponent<Monster>();
    }

    public void OnClickRenewButton()
    {
        if (CurrentChange < MaxChange)
        {
            var manager = FindObjectOfType<Battle>();
            manager.DrawCard();
            CurrentChange++;
            CardModule.CurrentChangeCard = 0;
        }
    }

    public void TurnEndButton()
    {
        CurrentChange = 0;
        CardModule.CurrentChangeCard = 0;

        //  몬스터 데미지 확인
        int damage = Character.Instance.Attack + DamageCal() - monster.Defense;
        monster.Hit(damage);
        Debug.Log(damage);

        //  캐릭터 데미지 확인
        damage = monster.Attack - Character.Instance.Defense;
        Character.Instance.Hit(damage);

        Debug.Log(monster.Hp);
        Debug.Log(Character.Instance.Hp);

        var manager = FindObjectOfType<Battle>();
        manager.DrawCard();
    }

    public int DamageCal()
    {
        int temp;

        //배열 작은수부터 차례대로 배열하기
        for (int i = 0; i < 5; i++)
        {
            for (int k = i + 1; k < 5; k++)
            {
                if (battle.CardsNum[i] % 13 > battle.CardsNum[k] % 13)
                {
                    temp = battle.CardsNum[i];
                    battle.CardsNum[i] = battle.CardsNum[k];
                    battle.CardsNum[k] = temp;
                }
            }
        }

        if (battle.CardsNum[0] / 13 == battle.CardsNum[1] / 13 &&
            battle.CardsNum[0] / 13 == battle.CardsNum[2] / 13 &&
            battle.CardsNum[0] / 13 == battle.CardsNum[3] / 13 &&
            battle.CardsNum[0] / 13 == battle.CardsNum[4] / 13 &&
            battle.CardsNum[0] / 13 == battle.CardsNum[5] / 13)
        {
            if (battle.CardsNum[0] % 13 + 1 == battle.CardsNum[1] % 13 &&
                battle.CardsNum[1] % 13 + 1 == battle.CardsNum[2] % 13 &&
                battle.CardsNum[2] % 13 + 1 == battle.CardsNum[3] % 13 &&
                battle.CardsNum[3] % 13 + 1 == battle.CardsNum[4] % 13)
            {
                //스트레이트플러쉬
                damage = 1000000;
                Debug.Log("스트플");
            }
            else
            {
                //플러쉬;
                damage = 400;
                Debug.Log("플러쉬");
            }
        }
        else if (battle.CardsNum[0] % 13 + 1 == battle.CardsNum[1] % 13 &&
                 battle.CardsNum[1] % 13 + 1 == battle.CardsNum[2] % 13 &&
                 battle.CardsNum[2] % 13 + 1 == battle.CardsNum[3] % 13 &&
                 battle.CardsNum[3] % 13 + 1 == battle.CardsNum[4] % 13)
        {
            //스트레이트;
            damage = 200;
            Debug.Log("스트레이트");
        }

        else if (battle.CardsNum[0] % 13 == battle.CardsNum[1] % 13)
        {
            if (battle.CardsNum[1] % 13 == battle.CardsNum[2] % 13)
            {
                if (battle.CardsNum[2] % 13 == battle.CardsNum[3] % 13)
                {
                    //포카드
                    damage = 3600;
                    Debug.Log("포카드");
                }

                else if (battle.CardsNum[3] % 13 == battle.CardsNum[4] % 13)
                {
                    //풀하우스
                    damage = 600;
                    Debug.Log("풀하우스");
                }

                else
                {
                    //트리플
                    damage = 40;
                    Debug.Log("트리플");
                }
            }

            else if (battle.CardsNum[2] % 13 == battle.CardsNum[3] % 13)
            {
                if (battle.CardsNum[3] % 13 == battle.CardsNum[4] % 13)
                {
                    //풀하우스
                    damage = 600;
                    Debug.Log("풀하우스");
                }

                else
                {
                    //투페어
                    damage = 20;
                    Debug.Log("투페어");
                }
            }

            else if (battle.CardsNum[3] % 13 == battle.CardsNum[4] % 13)
            {
                //투페어
                damage = 20;
                Debug.Log("투페어");
            }

            else
            {
                //원페어
                damage = 2;
                Debug.Log("원페어");
            }
        }

        else if (battle.CardsNum[1] % 13 == battle.CardsNum[2] % 13)
        {
            if (battle.CardsNum[2] % 13 == battle.CardsNum[3] % 13)
            {
                if (battle.CardsNum[3] % 13 == battle.CardsNum[4] % 13)
                {
                    //포카드
                    damage = 3600;
                    Debug.Log("포카드");
                }

                else
                {
                    //트리플
                    damage = 400;
                    Debug.Log("트리플");
                }
            }

            else if (battle.CardsNum[3] % 13 == battle.CardsNum[4] % 13)
            {
                //투페어
                damage = 20;
                Debug.Log("투페어");
            }

            else
            {
                //원페어
                damage = 2;
                Debug.Log("원페어");
            }
        }

        else if (battle.CardsNum[2] % 13 == battle.CardsNum[3] % 13)
        {
            if (battle.CardsNum[3] % 13 == battle.CardsNum[4] % 13)
            {
                //트리플
                damage = 400;
                Debug.Log("트리플");
            }

            else
            {
                //원페어
                damage = 2;
                Debug.Log("원페어");
            }
        }

        else if (battle.CardsNum[3] % 13 == battle.CardsNum[4] % 13)
        {
            //원페어
            damage = 2;
            Debug.Log("원페어");
        }

        else
        {
            //노페어
            damage = 1;
            Debug.Log("노페어");
        }

        return damage;
    }
}

//  이 함수가 사실 데미지 계산이고
//  어찌보면 이 게임에서 족보 이지