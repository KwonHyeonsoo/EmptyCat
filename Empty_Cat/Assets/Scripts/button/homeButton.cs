using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homeButton : MonoBehaviour
{
    
    public void HowToPlay() { }
    public void Play() {
        //만약 오프닝이 비활성화 상태라면 오프닝 영상을 틀기 + index =0, instance.clear() 실행 == 오프닝, open1이 활성화된다
        SceneManager.LoadScene("Home");
    }
    public void Close() { }
    //스크롤뷰가 활성화될때마다 open1수치에 따라 버튼이 활성화 비활성화
    public void goStage1()
    {
        GameManager.instance.goStage1();

        SceneManager.LoadScene("SampleScene");
        GameManager.instance.a++;
    }
    public void goStage2()
    {
        GameManager.instance.goStage2();

        SceneManager.LoadScene("2stage");
        GameManager.instance.a++;
    }
    public void goStage3()
    {
        GameManager.instance.goStage3();

        SceneManager.LoadScene("3stage");
        GameManager.instance.a++;
    }
    public void goStage4()
    {
        GameManager.instance.goStage4();

        SceneManager.LoadScene("4stage");
        GameManager.instance.a++;
    }
    public void goStage5()
    {
        GameManager.instance.goStage5();

        SceneManager.LoadScene("5stage");
        GameManager.instance.a++;
    }
    public void goStage6()
    {
        GameManager.instance.goStage6();

        SceneManager.LoadScene("6stage");
        GameManager.instance.a++;
    }
    public void goStage7()
    {
        GameManager.instance.goStage7();

        SceneManager.LoadScene("7stage");
        GameManager.instance.a++;
    }
    public void goStage8()
    {
        GameManager.instance.goStage8();

        SceneManager.LoadScene("8stage");
        GameManager.instance.a++;
    }
    public void goStage9()
    {
        GameManager.instance.goStage9();

        SceneManager.LoadScene("9stage");
        GameManager.instance.a++;
    }
    public void goStage10()
    {
        GameManager.instance.goStage1();

        SceneManager.LoadScene("10stage");
        GameManager.instance.a++;
    }
}
