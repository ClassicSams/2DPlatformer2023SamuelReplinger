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
    public float knockBackLenght, knockBackForce;
    private float knockBackCounter;
    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer theSR;
    public bool isLeft;
    public PauseMenu reference;
    public static PlayerController sharedInstance;
    public float bounceForce;
    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

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
        if (!reference.isPaused)
        {

          if (knockBackCounter <= 0)
          {
              theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
              isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);//OverlapCircle(punto donde se genera el círculo, radio del círculo, layer a detectar
                  
              if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded)
                    {
                       theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        canDoubleJump = true;
                      AudioManager.sharedInstance.PlaySFX(9);
                  }
                  else
                    {
                        if (canDoubleJump)
                        {
                            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                            canDoubleJump = false;
                          AudioManager.sharedInstance.PlaySFX(9);
                      }
                  }  
                }
                if (theRB.velocity.x < 0)
                {
                    theSR.flipX = false;
                    isLeft = true;
                }
                else if (theRB.velocity.x > 0)
                {
                    theSR.flipX = true;
                    isLeft = false;
                }
          }
          else
          {
              knockBackCounter -= Time.deltaTime;
              if (!theSR.flipX)
              {
                  theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
              }
              else
              {
                  theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
              }
          }
        }
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLenght;
        theRB.velocity = new Vector2(0f, knockBackForce);
        anim.SetTrigger("isHurt");

    }
    public void Bounce()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
        AudioManager.sharedInstance.PlaySFX(9);
    }

}
