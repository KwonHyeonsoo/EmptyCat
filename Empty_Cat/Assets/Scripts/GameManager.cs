using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤을 할당할 전역 변수

    //스테이지 현황
    public bool isDead = false;
    public bool isClear = false;
    public float coolTime = 0;
    public int goal;
    public int fixedPoint;
    private int index; //스테이지 숫자

    //스테이지 목표
    public bool opening = true;
    public bool ending = false;

    public bool open1 = true; //저장 프리팹
    private int goal1 = 5;
    private int fixedPoint1 =60;

    public bool open2 = false;//저장 프리팹
    private int goal2;
    private int fixedPoint2;

    public bool open3 = false;//저장 프리팹
    private int goal3;
    private int fixedPoint3;

    public bool open4 = false;//저장 프리팹
    private int goal4;
    private int fixedPoint4;

    public bool open5 = false;//저장 프리팹
    private int goal5;
    private int fixedPoint5;

    public bool open6 = false;//저장 프리팹
    private int goal6;
    private int fixedPoint6;

    public bool open7 = false;//저장 프리팹
    private int goal7;
    private int fixedPoint7;

    public bool open8 = false;//저장 프리팹
    private int goal8;
    private int fixedPoint8;

    public bool open9 = false;//저장 프리팹
    private int goal9;
    private int fixedPoint9;

    public bool open10 = false;//저장 프리팹
    private int goal10;
    private int fixedPoint10;

    

    public int a = 0;
    // 게임 시작과 동시에 싱글톤을 구성
    void Awake()
    {
        
        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            if (this != instance)//this가 현재 생성한 instance가 아니라면(이전에 생성한 instance가 있다면)
            {
                // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
                // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
                Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");

                Destroy(this.gameObject);//생성한 instance 파괴


            } }
        //플레이어프렙스 배열
        
        //playerprebs 체크
        }
    private void Start()
    {

        opening = PlayerPrefs.HasKey("opening");
        ending = PlayerPrefs.HasKey("ending");
        open1 = PlayerPrefs.HasKey("open1");
        open2 = PlayerPrefs.HasKey("open2");
        open3 = PlayerPrefs.HasKey("open3");
        open4 = PlayerPrefs.HasKey("open4");
        open5 = PlayerPrefs.HasKey("open5");
        open6 = PlayerPrefs.HasKey("open6");
        open7 = PlayerPrefs.HasKey("open7");
        open8 = PlayerPrefs.HasKey("open8");
        open9 = PlayerPrefs.HasKey("open9");
        open10 = PlayerPrefs.HasKey("open10");
    }
    public void goStage1()
    {
        instance.isDead = false;
        instance.isClear = false;
        instance.coolTime = 0;
        instance.goal = instance.goal1;
        instance.fixedPoint = instance.fixedPoint1;
        instance.index = 1;
    }
    public void goStage2()
    {
        instance.isDead = false;
        instance.isClear = false;
        instance.coolTime = 0;
        instance.goal = instance.goal2;
        instance.fixedPoint = instance.fixedPoint2;
        instance.index = 2;
    }
    public void goStage3()
    {
        instance.isDead = false;
        instance.isClear = false;
        instance.coolTime = 0;
        instance.goal = instance.goal3;
        instance.fixedPoint = instance.fixedPoint3;
        instance.index = 3;
    }
    public void goStage4()
    {
        instance.isDead = false;
        instance.isClear = false;
        instance.coolTime = 0;
        instance.goal = instance.goal4;
        instance.fixedPoint = instance.fixedPoint4;
        instance.index = 4;
    }
    public void goStage5()
    {
        instance.isDead = false;
        instance.isClear = false;
        instance.coolTime = 0;
        instance.goal = instance.goal5;
        instance.fixedPoint = instance.fixedPoint5;
        instance.index = 5;
    }
    public void goStage6()
    {
        instance.isDead = false;
        instance.isClear = false;
        instance.coolTime = 0;
        instance.goal = instance.goal6;
        instance.fixedPoint = instance.fixedPoint6;
        instance.index = 6;
    }
    public void goStage7()
    {
        instance.isDead = false;
        instance.isClear = false;
        instance.coolTime = 0;
        instance.goal = instance.goal7;
        instance.fixedPoint = instance.fixedPoint7;
        instance.index = 7;
    }
    public void goStage8()
    {
        instance.isDead = false;
        instance.isClear = false;
        instance.coolTime = 0;
        instance.goal = instance.goal8;
        instance.fixedPoint = instance.fixedPoint8;
        instance.index = 8;
    }
    public void goStage9()
    {
        instance.isDead = false;
        instance.isClear = false;
        instance.coolTime = 0;
        instance.goal = instance.goal9;
        instance.fixedPoint = instance.fixedPoint9;
        instance.index = 9;
    }
    public void goStage10()
    {
        instance.isDead = false;
        instance.isClear = false;
        instance.coolTime = 0;
        instance.goal = instance.goal10;
        instance.fixedPoint = instance.fixedPoint10;
        instance.index = 10;
    }

    
    public void clear() { 

        if(index == 11 || index == 10)//스테이지 10을 깼으면
        {
            PlayerPrefs.SetInt("ending", 1);//엔딩 활성화
        }
        else//오프닝,1~9를 깼으면
        {//"open " index+1 스테이지를 활성화
            index++;
            string a = "open" + index;
            PlayerPrefs.SetInt(a, 1);
            Debug.Log(a+"클리어");
        }

        opening = PlayerPrefs.HasKey("opening");
        ending = PlayerPrefs.HasKey("ending");
        open1 = PlayerPrefs.HasKey("open1");
        open2 = PlayerPrefs.HasKey("open2");
        open3 = PlayerPrefs.HasKey("open3");
        open4 = PlayerPrefs.HasKey("open4");
        open5 = PlayerPrefs.HasKey("open5");
        open6 = PlayerPrefs.HasKey("open6");
        open7 = PlayerPrefs.HasKey("open7");
        open8 = PlayerPrefs.HasKey("open8");
        open9 = PlayerPrefs.HasKey("open9");
        open10 = PlayerPrefs.HasKey("open10");

    }
}