using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  플레이어는 오직 한 명 이니까
//  플레이어를 싱글톤화 해도 괜찮아

//  단 플레이어가 삭제되지 않으므로 주의

public class Character : MonoSingleton<Character>
{
    //  어허 스태틱 에반데
    //  m_ 찍는거 사실 요즘엔 잘 안쓰는데 .. 나도 연식 플머가 되버려서 꼰대가 됬단다 허허
    //  안써도 됨
    [SerializeField] private int m_Coin;
    [SerializeField] private int m_MaxHp;
    [SerializeField] private int m_Attack;
    [SerializeField] private int m_Defense;
    private int m_Hp;

    //  이 값을 누군가 다른 애가 건드려야 할 경우 private 라서 못 주겠다고 생각하겠지만
    //  접근자를 만들어서 준다. 이렇게 하는 이유는 외부에서 값을 수정하지 못하도록 하기 위해서 (읽기 권한만 준다)
    public int Attack { get => m_Attack; }
    public int Defense { get => m_Defense; }
    public int Hp { get => m_Hp; }
    public int MaxHp { get => m_MaxHp; }

    //  만약 외부에서 설정해야한다면 설정자도 넣어준다 (읽기, 쓰기 권한 둘 다 준다)
    public int Coin { get => m_Coin; set => m_Coin = value; }

    public void Hit(int damage)
    {
        m_Hp -= damage;

        if (m_Hp <= 0)
        {
            BattlePageManager.Instance.ActiveLosePage = true;
        }
    }

    private void Awake()
    {
        m_Hp = m_MaxHp;
    }

    ////  Awake, Start 는 한 번만 호출되므로 객체가 생성되지 마자 HP 는 MaxHP 가 될 것이다
    ////  허나 누군가 건드리거나 이 객체가 재생성 (씬 나갔다가 다시 씬 나오면) 되면 똑같이 Awake 함수 실행됨 
    ////  이 기능은 플레이어가 갖는것 보다 Battle 이나 전투 담당 클래스가 하는게 좋아보임
    //public int CharacterAttack()
    //{
    //    int AttackDamage = Attack + gamemanager.DamageCal();

    //    return AttackDamage;
    //}
}