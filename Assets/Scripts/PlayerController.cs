using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private Rigidbody2D rb2d;
    private bool isJumping;

    public Text countText;
    public float jumpMultiplier = 2f;
    private bool facingRight;
    public int count;
    private GunController gun;
    

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb2d = GetComponent<Rigidbody2D>();
        
        isJumping = false;
        facingRight = true;
        SetCountText();


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

    public void AddCount()
    {
        count++;
        SetCountText();
    }

    private void Flip()
    {
        gun = gameObject.transform.GetChild(0).gameObject.GetComponent<GunController>();

        if (gun == null)
        {
            Debug.Log("q");
        }
        
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        gun.UnFlip();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
