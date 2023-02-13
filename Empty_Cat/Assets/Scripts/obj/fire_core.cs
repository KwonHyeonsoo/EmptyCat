using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_core : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();//상대방 게임 오브젝트에서 컴포넌트 가져오기

            //컴포포ㅗ넌트를 가져오는데 성공했다면
            if (playerController != null)
            {
                GameManager.instance.coolTime = 10;
                Destroy(gameObject);
                playerController.fireChanged();//소멸 메서드 실행

            }
        }
    }
}
