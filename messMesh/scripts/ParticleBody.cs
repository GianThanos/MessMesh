using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBody : MonoBehaviour
{
    public Transform feetPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    

    

    private ParticleSystem particleSystem1;

    public void Start()
    {
        particleSystem1 = GetComponent<ParticleSystem>();
    }




    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

    }

    private void Update()
    {

        var main = particleSystem1.main;
        if (isGrounded == true)
        {
            main.gravityModifier = 0;
        }
        else
        {
            main.gravityModifier = 0.2f ;
        }
    }
}
