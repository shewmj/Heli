using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private Rigidbody2D rb2d;
    private bool isjump;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isjump = false;

        
            
    }
    void FixedUpdate()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = 0;
        if (isjump)
        {
            vertical += 30;
            isjump = false;
        }
        
        
        
        Vector2 movement = new Vector2(horizontal, vertical);
        rb2d.AddForce(movement * speed);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isjump = true;
            animator.SetBool("IsJump", true);
        }

        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        
    }

    public void OnLanding()
    {
        animator.SetBool("IsJump", false);
    }
}
