using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class viewscrolling : MonoBehaviour
{

    public Scrollbar scrollbar;
    public float speed;
    private void OnEnable()
    {
        scrollbar.value = 0;
    }
    private void Update()
    {
        if (scrollbar.value < 0.99f)
        {
            scrollbar.value += Time.deltaTime * speed;
        }
    }
}
