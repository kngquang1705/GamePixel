using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;

    Animator anima;

    private int amountjumpsLeft;
    private int amountjumps = 1;
    private int jumpsIndexAnimation = 0;

    private float dirX;

    public float wallCheckDistance;
    public float wallSlideSpeed;

    private bool isTouchingWall;
    private bool isWallSliding;
    private bool isTouchingGround;
    private bool isGrounded;
    private bool isFacingRight =true;
    private bool canJumpp;
    private bool jumpOneTimeWhileStickInTheWall = true;

    private BoxCollider2D col;

    [SerializeField] private LayerMask ground;

    private enum MovementState { idle, running, jumping, falling};
    
    private MovementState state = MovementState.idle;

    [SerializeField] private AudioSource jumpSound;

    public Transform wallCheck;

    public GameObject pauseMenuScreen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();  
        col = GetComponent<BoxCollider2D>();
        amountjumpsLeft = amountjumps;
    }

    // Update is called once per frame
    void Update()
    {
        touchGround();
        PlayerMovement();
        CheckMovementDirection();
        CheckTouchingWall();
        setAnimation();
        checkIfCanJump();
        CheckIfWallSliding();
        menuLevel();
    }


    private void FixedUpdate()
    {

    }

    private void CheckTouchingWall()
    {
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, ground);
    }

    private void CheckIfWallSliding()
    {
        if(isTouchingWall && !isTouchingGround && rb.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    void PlayerMovement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (isTouchingWall)
        {
            if(rb.velocity.y < -wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }

        if (Input.GetKeyDown("space") && canJumpp)
        {
            //rb.velocity = new Vector3(0, 7, 0);

            rb.velocity = Vector3.up * 8f;
            jumpSound.Play();
            amountjumpsLeft--;
            Debug.Log("Jump");
        }
    }

    private void setAnimation()
    {
        if (dirX > 0)
        {
            state = MovementState.running;

        }
        else if (dirX < 0)
        {
            state = MovementState.running;

        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            //jumpsIndexAnimation = 0;
            state = MovementState.falling;
        }

        anima.SetInteger("state", (int)state);

        if (isWallSliding)
        {
            if (rb.velocity.y < -wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, wallSlideSpeed);
            }
        }
        //anima.SetInteger("doublejump", jumpsIndexAnimation);
        anima.SetBool("isWallSlide", isWallSliding); 
    }

    private void CheckMovementDirection()
    {
        if(isFacingRight && dirX < 0)
        {
            Flip();
        }
        else if(!isFacingRight && dirX > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void touchGround()
    {
        isTouchingGround = Physics2D.BoxCast(col.bounds.center, col.bounds.size, .0f, Vector2.down, .1f, ground);
    }

    private void checkIfCanJump()
    {
        if(isTouchingGround && rb.velocity.y <= 0)
        {
            amountjumpsLeft = amountjumps;
        }
        if(amountjumpsLeft <= 0)
        {
            canJumpp = false;
        }
        else
        {
            canJumpp = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            rb.velocity = Vector2.up * 15f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene(0);
    }

    void menuLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
