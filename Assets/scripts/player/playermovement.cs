using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class playermovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    AudioSource jumpAudioSource;


    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool facingRight = true;

    bool isShooting = false;
    bool isJumpShooting = false;
    bool upGrapple = false;
    bool isWalkShooting = false;
    public bool isCrouching = false;
    bool crouchShooting = false;
    public int health;

    public AudioClip jumpSFX;
    

      

   


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(rb);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

      

      

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 100;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.01f;
        }

        if(!groundCheck)
        {
            Debug.Log("GroundCheck does not Exist, Please set Transform Value for groundcheck");
        }

        if (health <= 0)
        {
            health = 3;
        }




    }


    // Update is called once per frame
    void Update()


    {
        
       

        if (Input.GetButtonDown("Fire1"))
        {
            isJumpShooting = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isJumpShooting = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
        }

        if(Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }

        if(Input.GetButtonDown("Vertical") && isGrounded)
        {
            upGrapple = true;
            rb.velocity = Vector2.zero;
        }

        if (Input.GetButtonUp("Vertical") && isGrounded)
        {
            upGrapple = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            isCrouching = true;
                        
        }

        if (Input.GetButtonUp("Fire2"))
        {
            isCrouching = false;
        }

        if (Input.GetButton("Fire2") && Input.GetButtonDown("Fire1"))
        {
            crouchShooting = true;
        }
       
        if (Input.GetButtonUp("Fire2") || Input.GetButtonUp("Fire1"))
        {
            crouchShooting = false;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Fire1") && horizontalInput != 0)
        {
            isWalkShooting = true;
        }

        if (Input.GetButton("Fire1") && horizontalInput == 0)
        {
            isWalkShooting = false;
        }

        //Flipping

        if (horizontalInput > 0 && facingRight == false)
        {
            Flip();
        }

        if (horizontalInput < 0 && facingRight == true)
        {
            Flip();
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

    


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            if (!jumpAudioSource)
            {
                jumpAudioSource = gameObject.AddComponent<AudioSource>();
                jumpAudioSource.clip = jumpSFX;
                jumpAudioSource.loop = false;
                jumpAudioSource.Play();
            }
            else
            {
                jumpAudioSource.Play();
            }
        }

        if (isCrouching)
        {
            speed = 0;
        }

        else if (!isCrouching)
        {
            speed = 5.0f;
        }


     




        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isShooting", isShooting);
        anim.SetBool("isJumpShooting", isJumpShooting);
        anim.SetBool("isWalkShooting", isWalkShooting);
        anim.SetBool("upGrapple", upGrapple);
        anim.SetBool("isCrouching", isCrouching);
        anim.SetBool("crouchShooting", crouchShooting);
        
        
        

    }

    void Flip()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        facingRight = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "proximity")
        {
            collision.gameObject.GetComponent<enemyTurret>().Fire();
        }

    }

    public void StartJumpForceChange()
    {
        StartCoroutine(JumpForceChange());
    }

    IEnumerator JumpForceChange()
    {
        jumpForce = 500;
        yield return new WaitForSeconds(2.0f);

        jumpForce = 300;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickups")
        {
            if (Input.GetKeyDown (KeyCode.E))
            {
                Pickups curPickup = collision.GetComponent<Pickups>();
                switch (curPickup.currentCollectible)
                {
                    case Pickups.CollectibleType.BOMB:
                        Destroy(collision.gameObject);

                        break;
                }
            }

 
        }
    }

    public void IsDead()
    {
        health--;
        
        if (health <= 0)
        {
            
            anim.SetBool("isDead", true);
            rb.velocity = Vector2.zero;
         
            speed = 0.1f;
        }


    }



    public void FinishedDeath()
    {
        Destroy(gameObject);
    }
}





