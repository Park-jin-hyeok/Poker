using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  �÷��̾�� ���� �� �� �̴ϱ�
//  �÷��̾ �̱���ȭ �ص� ������

//  �� �÷��̾ �������� �����Ƿ� ����

public class Character : MonoSingleton<Character>
{
    //  ���� ����ƽ ���ݵ�
    //  m_ ��°� ��� ���� �� �Ⱦ��µ� .. ���� ���� �øӰ� �ǹ����� ���밡 ��ܴ� ����
    //  �Ƚᵵ ��
    [SerializeField] private int m_Coin;
    [SerializeField] private int m_MaxHp;
    [SerializeField] private int m_Attack;
    [SerializeField] private int m_Defense;
    private int m_Hp;

    //  �� ���� ������ �ٸ� �ְ� �ǵ���� �� ��� private �� �� �ְڴٰ� �����ϰ�����
    //  �����ڸ� ���� �ش�. �̷��� �ϴ� ������ �ܺο��� ���� �������� ���ϵ��� �ϱ� ���ؼ� (�б� ���Ѹ� �ش�)
    public int Attack { get => m_Attack; }
    public int Defense { get => m_Defense; }
    public int Hp { get => m_Hp; }
    public int MaxHp { get => m_MaxHp; }

    //  ���� �ܺο��� �����ؾ��Ѵٸ� �����ڵ� �־��ش� (�б�, ���� ���� �� �� �ش�)
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

    ////  Awake, Start �� �� ���� ȣ��ǹǷ� ��ü�� �������� ���� HP �� MaxHP �� �� ���̴�
    ////  �㳪 ������ �ǵ帮�ų� �� ��ü�� ����� (�� �����ٰ� �ٽ� �� ������) �Ǹ� �Ȱ��� Awake �Լ� ����� 
    ////  �� ����� �÷��̾ ���°� ���� Battle �̳� ���� ��� Ŭ������ �ϴ°� ���ƺ���
    //public int CharacterAttack()
    //{
    //    int AttackDamage = Attack + gamemanager.DamageCal();

    //    return AttackDamage;
    //}
}