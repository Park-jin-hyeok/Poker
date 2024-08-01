using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public int past = 0;

    public void WinEndButton()
    {
        SceneManager.LoadScene(0);
        //커버 이미지 없애기
    }
    public void LoseEndButton()
    {
        SceneManager.LoadScene(0);
        //게임 초기화 하기
    }

    public void Scene1Click()
    {
        if (past == 0)
        {
            GameObject.Find("Enemy (0)").GetComponent<RectTransform>().sizeDelta = new Vector2(8, 8);
            GameObject.Find("Enemy (0)").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            GameObject.Find("Enemy (1)").GetComponent<RectTransform>().sizeDelta = new Vector2(12, 12);
            GameObject.Find("Enemy (1)").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            GameObject.Find("Enemy (2)").GetComponent<RectTransform>().sizeDelta = new Vector2(12, 12);
            GameObject.Find("Enemy (2)").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            SceneManager.LoadScene(1);
            past = 1;
        }
    }

    public void Scene2Click()
    {
        if (past == 1)
        {
            GameObject.Find("Enemy (1)").GetComponent<RectTransform>().sizeDelta = new Vector2(8, 8);
            GameObject.Find("Enemy (1)").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            GameObject.Find("Enemy (2)").GetComponent<RectTransform>().sizeDelta = new Vector2(8, 8);
            GameObject.Find("Enemy (2)").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            GameObject.Find("Shop (0)").GetComponent<RectTransform>().sizeDelta = new Vector2(12, 12);
            GameObject.Find("Shop (0)").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            GameObject.Find("Treasure (0)").GetComponent<RectTransform>().sizeDelta = new Vector2(12, 12);
            GameObject.Find("Treasure (0)").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            past = 2;
        }
    }

    public void Scene3Click()
    {
        if (past == 1)
        {
            GameObject.Find("Enemy (1)").GetComponent<RectTransform>().sizeDelta = new Vector2(8, 8);
            GameObject.Find("Enemy (1)").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            GameObject.Find("Enemy (2)").GetComponent<RectTransform>().sizeDelta = new Vector2(8, 8);
            GameObject.Find("Enemy (2)").GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            GameObject.Find("Treasure (0)").GetComponent<RectTransform>().sizeDelta = new Vector2(12, 12);
            GameObject.Find("Treasure (0)").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            GameObject.Find("Enemy (3)").GetComponent<RectTransform>().sizeDelta = new Vector2(12, 12);
            GameObject.Find("Enemy (3)").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            past = 2;
        }
    }
}
