using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float minusLife = 30;
    public GameObject hit;

    private AudioSource playerAudio;
    public AudioClip hitClip;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    //player와 충돌
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)//컴포넌트를 가져오는데 성공하면
            {
                playerController.Collide();
                hit.SetActive(true);
                playerAudio.clip = hitClip;
                playerAudio.Play();
                playerController.Life -= minusLife;//소멸 메서드 실행

            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)//컴포넌트를 가져오는데 성공하면
            {
                hit.SetActive(false);
                playerController.CollideExit();
            }
        }
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)//컴포넌트를 가져오는데 성공하면
            {
                hit.SetActive(false);
                playerController.CollideExit();
            }
        }
    }
}

