using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeCate : MonoBehaviour
{
    private Rigidbody2D playerRigidbody; //물리
    private CircleCollider2D playerCollider; //충돌

    public Sprite defalut;
    public Sprite jump;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidbody.velocity = new Vector2(3, playerRigidbody.velocity.y);

        if (playerRigidbody.position.x >= 12)
        {
            this.transform.position = new Vector2(-13.5f, 5);
        }
        if (playerRigidbody.transform.position.y <= -2.7)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = defalut;
            playerRigidbody.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);

        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = jump;
        }
    }
}
