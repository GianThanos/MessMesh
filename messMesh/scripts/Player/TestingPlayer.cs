using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPlayer : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private Animator anim;

    public int PlayerHealth;
    public int maxPlayerHealth;
    public int damage;
    public GameObject deathEffect;

    public HealthBarBehavior HealthBar;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);





        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {

            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if ((Input.GetKey(KeyCode.Space)) && (isJumping = true))
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Damage");
            PlayerHealth -= damage;
            

            if (PlayerHealth <= 0)
            {

                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                


            }
            HealthBar.SetHealth(PlayerHealth, maxPlayerHealth);
        }

    }



}
