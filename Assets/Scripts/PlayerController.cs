using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D theRB;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);//OverlapCircle(punto donde se genera el círculo, radio del círculo, layer a detectar
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
               theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }
        if (theRB.velocity.x < 0)
        {
            theSR.flipX = false;
        }
        else if (theRB.velocity.x > 0)
        {
            theSR.flipX = true;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }
}
