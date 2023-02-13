using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class homeScrollView : MonoBehaviour
{
    // Start is called before the first frame update

    //버튼 목록
    public Button[] Bttns;
    void OnEnable()
    {

        if (GameManager.instance.open2)
        {
            Bttns[2].interactable = true;
        }
        if (GameManager.instance.open3)
        {
            Bttns[3].interactable = true;
        }
        if (GameManager.instance.open4)
        {
            Bttns[4].interactable = true;
        }
        if (GameManager.instance.open5)
        {
            Bttns[5].interactable = true;
        }
        if (GameManager.instance.open6)
        {
            Bttns[6].interactable = true;
        }
        if (GameManager.instance.open7)
        {
            Bttns[7].interactable = true;
        }
        if (GameManager.instance.open8)
        {
            Bttns[8].interactable = true;
        }
        if (GameManager.instance.open9)
        {
            Bttns[9].interactable = true;
        }
        if (GameManager.instance.open10)
        {
            Bttns[10].interactable = true;
        }
        if (GameManager.instance.ending || GameManager.instance.a>=20)
        {
            Bttns[11].interactable = true;
        }

    }

}
