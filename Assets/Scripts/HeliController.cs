using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class HeliController : MonoBehaviour
{

    private GameObject player;
    private bool dropped;
    public GameObject ak47pickup;
    private Rigidbody2D rb2d;
    private int randomNum;
    private System.Random rnd;
    private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        player = GameObject.Find("Player");
        dropped = false;
        rb2d = GetComponent<Rigidbody2D>();
        isRight = true;
    }

  
    void Update()
    {
        if(player.GetComponent<PlayerController>().count > 10 && !dropped)
        {
            dropped = true;
            Instantiate(ak47pickup, transform.position, transform.rotation);
        }


        if(randomNum == 0)
        {
            isRight = !isRight;
            NewRandomNum();
            
        }

        rb2d.AddForce(new Vector2(randomNum, 0), ForceMode2D.Impulse);
        if(randomNum < 0)
        {
            randomNum++;
        } else
        {
            randomNum--;
        }
       
    }

    private void NewRandomNum()
    {
        randomNum = rnd.Next(1, 3);  
        if(!isRight)
        {
            randomNum *= -1;
        }
    }




}
