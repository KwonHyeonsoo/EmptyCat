using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage1Button : MonoBehaviour
{
    public void gotoHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.instance.isDead = false;
        GameManager.instance.isClear = false;

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
        GameManager.instance.goStage10();

        SceneManager.LoadScene("10stage");
        GameManager.instance.a++;
    }
}
