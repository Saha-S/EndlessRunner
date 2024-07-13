using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHight;
    private Rigidbody2D rigid;

    public LayerMask whatIsGround;
    private bool grounded;
    //Collider2D myCollider;

    private Animator anim;

    // inhance jumping
    public float jumpTime;
    float jumpTimeCounter;

    public float speedMultiplier;
    public float increaseSpeed;
    float speedCount;

    public Transform groundCheck;
    public float groundRadios;

    bool stopJump;
    bool can2jump;

    public GameManager theGameManager;

    float resetMoveSpeed;
    float resetSpeedCounter;
    float resetSpeedIncrease;

    public AudioSource jumpSound, deathSound;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
      //  myCollider = GetComponent<Collider2D>();

        anim = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedCount = increaseSpeed;

        stopJump = true;

        theGameManager = FindAnyObjectByType<GameManager>();

        // for reset move speed after player die
        resetMoveSpeed = moveSpeed;
        resetSpeedCounter = speedCount;
        resetSpeedIncrease = increaseSpeed;
    }

    private void Update()
    {
        // grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position , groundRadios , whatIsGround);

        // Increase Speed Game after a distance
        if (transform.position.x> speedCount)
        {
            speedCount += increaseSpeed;


            // change the distance for next level
            increaseSpeed += increaseSpeed * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }
        
        
        rigid.velocity = new Vector2 (moveSpeed, rigid.velocity.y);

        // if press Space or left click mouse
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ){
            if (grounded)
            {
                rigid.velocity = new Vector2(moveSpeed * 1.1f, jumpHight);
                stopJump = false;
                jumpSound.Play();
            }
            if (!grounded && can2jump) {
                rigid.velocity = new Vector2(moveSpeed * 1.1f, jumpHight);
                
                can2jump = false;
                stopJump=false;
                jumpSound.Play();
            }
            }

            if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stopJump)
            {
                if(jumpTimeCounter > 0)
                {
                    rigid.velocity = new Vector2(moveSpeed*1.5f , jumpHight);
                    jumpTimeCounter -= Time.deltaTime;
                }

            }

            // to unable jump on the air
            if((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)))
            {
                jumpTimeCounter = 0;
                stopJump = true;
            }
            // to able jump long again
            if (grounded)
            {
                jumpTimeCounter = jumpTime;
                can2jump = true;
            }
            anim.SetBool("Grounded", grounded);
        

}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "killBox")
        {
            theGameManager.RestartGame();

            // reset move speed after player die
            moveSpeed = resetMoveSpeed;
            speedCount = resetSpeedCounter;
            increaseSpeed = resetSpeedIncrease;
            deathSound.Play();
        }
    }
}
