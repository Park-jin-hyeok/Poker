using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public int MaxHp;
    public int Hp;
    public int Attack;
    public int Defense;
    public int MinCoin;
    public int MaxCoin;

    public bool IsAttack;

    public Slider Hpbar;

    private void Start()
    {
        Hp = MaxHp;
    }

    private void Update()
    {
        Hpbar.value = (float)Hp / (float)MaxHp;
    }

    private IEnumerator UpdateChange()
    {
        float time = 0.5f;

        if (IsAttack == true)
        {
            float currentTime = Time.time;
            while (Time.time - currentTime <= time)
            {
                GameObject.Find("Enemy1").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                yield return null;
            }

           currentTime = Time.time;
            while (Time.time - currentTime <= time)
            {
                GameObject.Find("Enemy1").GetComponent<Image>().color = new Color(1, 1, 1, 1);
                yield return null;
            }
           IsAttack = false;
        }
        yield break;
    }

    public void Hit(int damage)
    {
        Hp -= damage;

        IsAttack = true;
        UpdateChange();

        if (Hp <= 0)
        {
            int RanCoin = Random.Range(MinCoin, MaxCoin);
            Character.Instance.Coin += RanCoin;

            BattlePageManager.Instance.ActiveWinPage = true;
        }
    }
}