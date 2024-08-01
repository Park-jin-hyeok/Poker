using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public Monster monster;

    private float moveSpeed;
    private float alphaSpeed;
    private float destroyTime;
    TextMeshPro text;
    Color alpha;

    // Start is called before the first frame update
    void Start()
    {
        monster = GameObject.Find("Enemy1").GetComponent<Monster>();
        text = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if (monster.IsAttack == true)
        {
            moveSpeed = 3.0f;
            alphaSpeed = 3.0f;
            destroyTime = 1.0f;

            text.text = BattleManager.damage.ToString();

            alpha = text.color;

//           Invoke("DestroyObject", destroyTime);

            transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0)); // 텍스트 위치

            alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); // 텍스트 알파값
            text.color = alpha;
            monster.IsAttack = false;
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}