using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    private float width; // 배경의 가로 길이
    public CameraManager Camera;
    private float distance = 25;
    private float speed = 0.01f;
    private Vector2 vector;
    private void Awake()
    {
        //시작은 원래 위치
        vector = new Vector2(this.transform.position.x, this.transform.position.y);
        // 가로 길이를 측정하는 처리
        //boxcliider 2D 컴포넌트의 size필드의 x값을 가로 길이로 사용
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
   
    }

    private void Update()
    {
        if (!Camera.isStop() || GameManager.instance.isDead )
            
        {
            //return;
            vector = new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.position = vector;
        }
        else
        {
            if (Camera.transform.position.x - transform.position.x < distance)
            {
                this.transform.position = Vector2.Lerp(vector, new Vector2(this.transform.position.x + speed, this.transform.position.y), 1 * Time.deltaTime);
                vector = new Vector2(this.transform.position.x + speed, this.transform.position.y);
            }
            else
            {
                this.transform.position = new Vector2(this.transform.position.x + width * 2f, this.transform.position.y);
                vector = new Vector2(this.transform.position.x , this.transform.position.y);
            }
        }


    }

    // 위치를 리셋하는 메서드

}
