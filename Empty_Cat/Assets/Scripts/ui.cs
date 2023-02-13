using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ui : MonoBehaviour
{
    public PlayerController player;
    //ui
    //Ã¼·Â¹Ù
    public Canvas Canvas;
    public Slider slider;
    
    //flowerCount
    public Text flowerCount;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = player.Life;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.Life;
        //flowerCount
        flowerCount.text = player.flowerPoint + "/" + player.goalPoint;
    }
}
