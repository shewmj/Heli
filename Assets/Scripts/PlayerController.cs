using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private Rigidbody2D rb2d;
    private bool isJumping;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpMultiplier = 2f;
    private bool facingRight;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isJumping = false;
        facingRight = true;
       
            
    }
    void FixedUpdate()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal < 0 && facingRight)
        {
            Flip();
            
        } else if(horizontal > 0 && !facingRight)
        {
            Flip();
            
        }

        float vertical = rb2d.velocity.y;
        if (isJumping)
        {
            vertical += 15 * jumpMultiplier;
            isJumping = false;
        }
        

        Vector2 movement = new Vector2(horizontal * speed, vertical);
        
        rb2d.velocity = movement;




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            animator.SetBool("IsJump", true);
        }
       

        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        
    }

    public void OnLanding()
    {
        animator.SetBool("IsJump", false);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
