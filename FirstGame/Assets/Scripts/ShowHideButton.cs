using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideButton : MonoBehaviour
{
    public GameObject CoverImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        CoverImage.SetActive(false);
    }
}
