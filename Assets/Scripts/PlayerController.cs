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
    public bool facingRight;
    public int count;
    
    public GameObject pistol;
    public GameObject ak47;
    public GameObject m4;
    public GameObject mp5;
    public GameObject p90;
    public GameObject shotgun;
    public GameObject sniper;
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
        float vertical = rb2d.velocity.y;
        if (isJumping)
        {
            vertical += 15 * jumpMultiplier;
            isJumping = false;
        }

        Vector2 movement = new Vector2(horizontal * speed, vertical);
        rb2d.velocity = movement;

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            animator.SetBool("IsJump", true);
        }
        
        //
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
            return;
        }


        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0 && facingRight)
        {
            Flip();
        } else if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("AK47Pickup"))
        {
            other.gameObject.SetActive(false);
            GameObject temp = Instantiate(ak47, transform.position, transform.rotation);
            temp.SetActive(false);
            temp.transform.parent = transform;
        } else if (other.gameObject.CompareTag("M4Pickup"))
        {
            other.gameObject.SetActive(false);
            GameObject temp = Instantiate(m4, transform.position, transform.rotation);
            temp.SetActive(false);
            temp.transform.parent = transform;
        }else if (other.gameObject.CompareTag("MP5Pickup"))
        {
            other.gameObject.SetActive(false);
            GameObject temp = Instantiate(mp5, transform.position, transform.rotation);
            temp.SetActive(false);
            temp.transform.parent = transform;
        } else if (other.gameObject.CompareTag("P90Pickup"))
        {
            other.gameObject.SetActive(false);
            GameObject temp = Instantiate(p90, transform.position, transform.rotation);
            temp.SetActive(false);
            temp.transform.parent = transform;
        }else if (other.gameObject.CompareTag("ShotgunPickup"))
        {
            other.gameObject.SetActive(false);
            GameObject temp = Instantiate(shotgun, transform.position, transform.rotation);
            temp.SetActive(false);
            temp.transform.parent = transform;
        }else if (other.gameObject.CompareTag("SniperPickup"))
        {
            other.gameObject.SetActive(false);
            GameObject temp = Instantiate(sniper, transform.position, transform.rotation);
            temp.SetActive(false);
            temp.transform.parent = transform;
        }

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
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        gameObject.transform.GetChild(currentSlot).gameObject.GetComponent<GunController>().UnPlayerFlip();
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
