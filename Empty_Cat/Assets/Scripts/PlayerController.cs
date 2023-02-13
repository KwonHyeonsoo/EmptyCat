using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 100f;//점프 힘
    private bool isGrounded = true;//지반
    public float Life = 200;//체력
    public float plusLife = 30;
    public float LifeConsume = 0.1f;
    public int movement; //-1이면 down, 0이면 보통 +1이면 jump
    public int state = 0; //-1이면 불, 0이면 무능력, +1이면 물
    public float playerSpeed = 8f;

    //목표
    public int flowerPoint;//클리어 포인트
    public float fixedPoint;
    public float goalPoint;

    //ui
    //gameover
    public GameObject gameover;
    //clear
    public GameObject clear;

    //컴포넌트
    private Animator Animator;
    private Rigidbody2D playerRigidbody; //물리
    private CircleCollider2D playerCollider; //충돌

    //오디오소스 컴포넌트
    private AudioSource playerAudio;
    public AudioClip deathClip; // 오디오 클립
    public AudioClip clearClip;
    public AudioClip jumpClip;
    public AudioClip downClip;
    public AudioClip lifeClip;


    // Start is called before the first frame update
    void Start()
    {//초기화
       GameManager.instance.isClear = false;
       GameManager.instance.isDead = false;

        flowerPoint = 0;
        /*fixedPoint = GameManager.instance.fixedPoint;
        goalPoint = GameManager.instance.goal;
        */

    movement = 0;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CircleCollider2D>();
        playerAudio = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //die
        if (Life <= 0 || (playerRigidbody.position.x >= fixedPoint && flowerPoint<goalPoint) || playerRigidbody.position.y < -10)
        {
            playerCollider.isTrigger = false;
            if (!GameManager.instance.isDead)
            { Die(); }
        }

        else
        {
            if (!Clear())
            {
                //ui
                //체력 닳음
                Life -= LifeConsume*Time.deltaTime;
                

                //x속력
                playerRigidbody.velocity = new Vector2(playerSpeed, playerRigidbody.velocity.y);

                //점프
                if (Input.GetAxis("Vertical") > 0 && isGrounded)
                {
                    //playerRigidbody.velocity = Vector2.zero;
                    playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                    isGrounded = false;
                    movement = +1;

                    playerAudio.clip = jumpClip;
                    playerAudio.Play();
                }
                if (movement > 0 && playerRigidbody.velocity.y > 0) //jump상태이면서 위로 상승하면 
                {
                    playerCollider.isTrigger = true;
                }
                else if (movement > 0 && playerRigidbody.velocity.y < 0)
                {
                    playerCollider.isTrigger = false;
                }


                //다운 
                if (Input.GetAxis("Vertical") < 0 && isGrounded && playerRigidbody.position.y > -2f)
                {
                    movement = -1;
                    playerCollider.isTrigger = true;

                    playerAudio.clip = downClip;
                    playerAudio.Play();
                }

                //체력 넘침
                if (Life > 200)
                {
                    Life = 200;
                }
                
            }

            else //클리어한다면
            {
                playerCollider.isTrigger = false;
                playerRigidbody.velocity = new Vector2(0,0); //속력은 0
                Animator.SetBool("clear", true);
                clear.gameObject.SetActive(true);

                if (!GameManager.instance.isClear) {
                    playerAudio.clip = clearClip;
                    playerAudio.Play();
                    GameManager.instance.isClear = true;
                    GameManager.instance.clear();
                }
                

                
            }
        }

    }
    public void Collide()
    {
        Animator.SetBool("collider", true);
    }
    public void CollideExit()
    {
        Animator.SetBool("collider", false);
    }

    public void getLife()
    {
        Life += plusLife; ;
        flowerPoint++;
        playerAudio.clip = lifeClip;
        playerAudio.Play();
    }
    private void Die() {
        GameManager.instance.isDead = true;
        playerRigidbody.velocity = new Vector2(0,0);//플레이어 이동 정지
        playerAudio.clip =deathClip;
        playerAudio.Play();
        Animator.SetTrigger("die");
        gameover.gameObject.SetActive(true);
        GameManager.instance.isDead = true;
        Life = 0;

    }

    public bool Clear()//클리어 검사
    {
        if (playerRigidbody.position.x >= fixedPoint && flowerPoint >= goalPoint)
        {
            return true;
        }else { return false; }
    }
    
    public void fireChanged() {
        state = -1;
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = fire;
        Animator.SetInteger("state", -1);
        
    }
    public void waterChanged() {
        state = +1;
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = water;
        Animator.SetInteger("state", +1);
        
    }

    //Trigger 상태
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        //어떤 콜라이더와 떨어졌을 때 
        if (movement !=0 && playerCollider.isTrigger && collision.tag =="Ground") //down jump이면
        {
            playerCollider.isTrigger = false;
        }
    }     

    //collision 상태    
    private void OnCollisionStay2D(Collision2D collision)
    {
        //어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있으면 
        if (collision.contacts[0].normal.y > 0.7f )
        {
            isGrounded = true;
            playerCollider.isTrigger = false;
            movement = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
