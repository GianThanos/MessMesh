using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingChar2 : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool lookingRight = true;

    private bool doubleJump = false;

    private Animator anim;

    public int PlayerHealth;
    public int maxPlayerHealth;
    public int damage;
    public GameObject deathEffect;

    public HealthBarBehavior HealthBar;

    public GameObject cloud;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (isGrounded)
            doubleJump = false;


        float hor = Input.GetAxis("Horizontal");

        

        rb.velocity = new Vector2(hor * maxSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if ((hor > 0 && !lookingRight) || (hor < 0 && lookingRight))
            Flip();


        cloud.transform.rotation = Quaternion.Euler(0, 0, 0);



    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && (isGrounded || !doubleJump))
        {
            rb.AddForce(new Vector2(0, jumpForce));

            anim.SetTrigger("takeOff");


            //anim.SetBool("isJumping", true);
   

            if (!doubleJump && !isGrounded)
            {
                doubleJump = true;
                anim.SetBool("isJumping", true);


            }
        }


        if (Input.GetButtonDown("Vertical") && !isGrounded)
        {
            rb.AddForce(new Vector2(0, -jumpForce));


        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        /*else
        {
            anim.SetBool("isJumping", true);
        }*/

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        StartCoroutine(Cloud());
        
        
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

    public void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }

    IEnumerator Cloud()
    {
        cloud.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        cloud.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(1);
        cloud.gameObject.SetActive(false);
        
    }




}
