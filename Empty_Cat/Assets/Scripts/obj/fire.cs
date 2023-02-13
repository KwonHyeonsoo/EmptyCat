using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//전진 이동
//접촉 혹은 일정 시간 지나면 소멸
public class fire : MonoBehaviour
{
    //이동 속력
    public float speed = 20f;
    private Rigidbody2D body;
    private float time;
    private Animator animator;
    // Start is called before the first frame update

    private void OnEnable()
    {
        speed = 20f;
        time = 1f;
        body = GetComponent<Rigidbody2D>();
        body.velocity = transform.right * speed;
        animator = GetComponent<Animator>();
        //3초뒤에 자신의 게임 오브젝트 파괴
        //Destroy(gameObject, 3f);
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
        //충돌한 게임 오브젝트 태그가 enemy일 경우
        if (collision.tag ==  "enemy")
        {
            enemy enemy = collision.GetComponent<enemy>();//상대방 게임 오브젝트에서 컴포넌트 가져오기

            //컴포포ㅗ넌트를 가져오는데 성공했다면
            if (enemy != null)
            {
                speed = 0f;
                body.velocity = transform.right * speed;
                animator.SetTrigger("collider");
                enemy.Die();//소멸 메서드 실행
                //Destroy(gameObject);
                //gameObject.SetActive(false);
            }
        }
    }
}

