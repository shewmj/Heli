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
    
    public GameObject handgun;
    public GameObject ak47;
    private int currentSlot;



    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb2d = GetComponent<Rigidbody2D>();
        currentSlot = 0;
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
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.GetChild(currentSlot).gameObject.SetActive(false);


            if(currentSlot < transform.childCount - 1)
            {
                currentSlot++;
            } else
            {
                currentSlot = 0;
            }
            
            transform.GetChild(currentSlot).gameObject.SetActive(true);

            
        }
        //CheckWeapons();
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("AK47pickup"))
        {
            other.gameObject.SetActive(false);
            GameObject temp = Instantiate(ak47, transform.position, transform.rotation);
            temp.SetActive(false);
            temp.transform.parent = transform;
        }

    }



    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        gameObject.transform.GetChild(currentSlot).gameObject.GetComponent<GunController>().UnFlip();
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }


    public void ResetWeapon()
    {
        currentSlot = 0;
        transform.GetChild(currentSlot).gameObject.SetActive(true);
    }
}
