using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider Hpbar;

    void Update()
    {
        Hpbar.value = (float)Character.Instance.Hp / (float)Character.Instance.MaxHp;
    }
}
