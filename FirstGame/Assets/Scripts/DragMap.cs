using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMap : MonoBehaviour
{
    public Camera MainCam;
    public Vector2 CamPos;
    public Vector2 Pre_MousePos;
    public Vector2 Now_MousePos;
    public Vector2 PosCal;
    public GameObject ControlTarget;

    public GameManager gamemanager;

    void Start()
    {
        MainCam = Camera.main;

        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {        
        if (gamemanager.CoverImage.activeSelf == false)
        {
            if (Input.GetMouseButtonDown(0)) //���콺 ��ư�� ������ ��
            {
                if (ControlTarget == null)
                {
                    Pre_MousePos = MainCam.ScreenToViewportPoint(Input.mousePosition); //���콺 ���� ��ġ ����
                    CamPos = this.transform.position;
                    Debug.Log("x��ǥ�� : " + CamPos.x + " y��ǥ�� : " + CamPos.y);
                }
            }

            else if (Input.GetMouseButton(0)) //���콺 ��ư�� ������ ����
            {
                if (ControlTarget == null)
                {
                    Now_MousePos = MainCam.ScreenToViewportPoint(Input.mousePosition);
                    PosCal = Now_MousePos - Pre_MousePos;
                    if (CamPos.y - PosCal.y <= 0 || CamPos.y - PosCal.y >= 5.4)
                    {
                    }
                    else
                    {
                        this.transform.position = new Vector3(CamPos.x, CamPos.y - PosCal.y, this.transform.position.z);
                    }
                }
            }
        }
        else
        {
            this.transform.position = new Vector3(CamPos.x, 0, this.transform.position.z);
        }
    }
}
