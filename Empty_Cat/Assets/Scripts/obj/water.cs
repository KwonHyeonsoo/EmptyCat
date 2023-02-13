using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D body;
    private float time;
    private Animator animator;
    private Vector2 vector= new Vector2(1,0);
    // Start is called before the first frame update
    private void OnEnable()
    {
        vector = new Vector2(1, 0);
        time = 1f;
        speed = 20f;
        body = GetComponent<Rigidbody2D>();
        body.velocity = vector * speed;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (body != null)
        {
            body.velocity = transform.right * speed;
            time -= Time.deltaTime;
            if (time <= 0)
            {

                gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("null 객체가 존재합니다.");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.tag == "flower")
        {
            flower flower = collision.GetComponent<flower>();//상대방 게임 오브젝트에서 컴포넌트 가져오기

            //컴포포ㅗ넌트를 가져오는데 성공했다면
            if (flower != null)
            {
                speed = 0f;
                body.velocity = transform.right * speed;
                animator.SetTrigger("collider");
                //Destroy(gameObject);
                flower.Change();//소멸 메서드 실행
                //gameObject.SetActive(false);
            }
        }
    }
}
