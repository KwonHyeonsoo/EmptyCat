using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{

    public Image image;

    float fadecount = 1f;
    private void OnEnable()
    {
        fadecount = 1f;
    }
    private void Update()
    {
        
        if (fadecount > 0f)
        {
            fadecount -= Time.deltaTime;

            image.color = new Color(0, 0, 0, fadecount);
        }
    }
}