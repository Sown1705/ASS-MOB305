using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;
    bool  jumped, jumping, grounded = true;
    float speed = 5f,height=10f,jumpTime;
    int moveState;
    // Start is called before the first frame update
    void Start()
    {
        //anh xa
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        State();
    }
	private void FixedUpdate()
	{
		if(!Input.GetKey(KeyCode.RightArrow) || !(Input.GetKey(KeyCode.UpArrow) || !Input.GetKey(KeyCode.LeftArrow)))
        {
            moveState = 0;
		}
        if(Input.GetKey(KeyCode.RightArrow)){
            moveState = 1;
		}
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveState = 2;
        }
        Jump();
    }

    void Jump()
	{
		if (Input.GetKey(KeyCode.UpArrow) )
		{

			if (grounded)
			{
                rbody.velocity = new Vector2(rbody.velocity.x, height);
            }
			
		}
        if(jumping && jumped)
		{
            rbody.gravityScale -= (0.1f * Time.fixedDeltaTime);
		}
		if (jumpTime > 1f)
		{
            jumping = false;
		}
        if(jumping && jumped)
		{
            rbody.gravityScale += .2f;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.tag == "Obstacle")
		{
            gameObject.SetActive(false);
            
            Time.timeScale = 0;
            GameController.instance.GameOver();
        }
        
    }
	private void OnTriggerStay2D(Collider2D collision)
	{//xac dinh nhan vat dang dung tren dat hay khong
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumped = false;
            jumping = false;

            anim.SetBool("isJump", false);
            anim.SetBool("isRunning", false);
            jumpTime = 0;
            rbody.gravityScale = 1;
        }
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Obstacle")
		{
            gameObject.SetActive(false);
            Time.timeScale = 0;//dung game hoan toan
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.gameObject.tag=="Ground")
		{
            grounded = false;
		}
	}
    void State()
	{
		switch (moveState)
		{
            case 1:
                anim.SetBool("isRunning", true);
                anim.SetBool("isJump", false);
                gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                //quay đầu
                if (gameObject.transform.localScale.x < 0)//xác định tiến hoặc lùi
                {
                    gameObject.transform.localScale =
                        new Vector3(gameObject.transform.localScale.x * -1,
                                gameObject.transform.localScale.y,
                                gameObject.transform.localScale.z);
                }
                break;
            case 2:
                anim.SetBool("isRunning", true);
                anim.SetBool("isJump", false);
                gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                //quay đầu
                if (gameObject.transform.localScale.x > 0)//xác định tiến hoặc lùi
                {
                    gameObject.transform.localScale =
                        new Vector3(gameObject.transform.localScale.x * -1,
                                gameObject.transform.localScale.y,
                                gameObject.transform.localScale.z);
                }
                break;
            default:
                speed = 5f;
                anim.SetBool("isRunning", false);
                anim.SetBool("isJump", false);
                break;
		}
		if (Input.GetKey(KeyCode.UpArrow) && !grounded)
		{
            anim.SetBool("isJump", true);
            anim.SetBool("isRunning", false);
            jumped = true;
            jumping = true;
            jumpTime += Time.fixedDeltaTime;

		}
        else
		{
            jumping = false;
		}
	}
}
