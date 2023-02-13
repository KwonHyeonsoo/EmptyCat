using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballSpawner : MonoBehaviour
{
    public GameObject firePrefab;
    private GameObject[] fireArray;
    private int fireCount = 6; //최대 불공 개수
    private float fireCooltime = 2.5f; //파이어볼 쿨타임
    private int fireIndex = 0; //파이어볼 순서

    public GameObject waterPrefab;
    private GameObject[] waterArray;
    private int waterCount = 3; //최대 물공 개수
    private float waterCooltime = 0.7f; //물공 쿨타임
    private int waterIndex = 0; //물공 순서

    //private float time = 0;//쿨타임 측정
    private Vector2 position = new Vector2(-10, -10);
    public PlayerController player;
    private Rigidbody2D playerbody;

    public Canvas Canvas;
    public Slider slider;

    //오디오
    public AudioClip launcherClip;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.coolTime = 10;

        playerbody = player.GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();

        fireArray = new GameObject[fireCount];
        waterArray = new GameObject[waterCount];

        for (int i = 0; i < fireCount; i++)//파이어볼 복제 생성
        {
            fireArray[i] = Instantiate(firePrefab, position, Quaternion.identity);
        }
        for (int i = 0; i < waterCount; i++)//파이어볼 복제 생성
        {
            waterArray[i] = Instantiate(waterPrefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isDead || player.Clear())
        {
            return;
        }

        GameManager.instance.coolTime += Time.deltaTime;
        slider.value = GameManager.instance.coolTime;

        if (GameManager.instance.coolTime >= 10)
        {
            GameManager.instance.coolTime = 10;
        }
        //쿨타임 다 차면 비활성화

        if(slider.value >= slider.maxValue)
        {
            Canvas.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
        {
            if (player.state == -1 && GameManager.instance.coolTime >= fireCooltime)//불공 발사
            {
                playerAudio.clip = launcherClip;
                playerAudio.Play();
                fireArray[fireIndex].SetActive(true);
                fireArray[fireIndex].transform.position = new Vector2(playerbody.transform.position.x, playerbody.transform.position.y);
                GameManager.instance.coolTime = 0;
                fireIndex++;
                if (fireIndex >= fireCount)
                {
                    fireIndex = 0;
                }

                //쿨타임바
                Canvas.gameObject.SetActive(true);
                slider.maxValue = fireCooltime;
                
            }

            if (player.state == +1 && GameManager.instance.coolTime >= waterCooltime)//물공 발사
            {
                playerAudio.clip = launcherClip;
                playerAudio.Play();
                waterArray[waterIndex].SetActive(true);
               waterArray[waterIndex].transform.position = new Vector2(playerbody.transform.position.x, playerbody.transform.position.y);
                GameManager.instance.coolTime = 0;
                waterIndex++;
                if (waterIndex >=  waterCount)
                {
                    waterIndex = 0;
                }
                Canvas.gameObject.SetActive(true);
                slider.maxValue = waterCooltime;
                
            }
        }

    }
}
