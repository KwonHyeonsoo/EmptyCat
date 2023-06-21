using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour
{
    public bool lifeState = false;
    
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeState)
        {
            Change();
        }
    }
    public void Change()
    {
        lifeState = true;
        animator.SetBool("LifeFlower", true);
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = life;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)//컴포넌트를 가져오는데 성공하면
            {
                if (lifeState)
                {
                    playerController.getLife();
                    Destroy(gameObject);//소멸 메서드 실행
                }
            }
        }
    }
}
