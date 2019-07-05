using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{

    
    private Vector3 offset;
    private Rigidbody2D rb2d;
    public int bulletSpeedDecrease;
    private GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       
        transform.Rotate(0, 0, 270f, Space.Self);

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
        float x = (mousePos.x - gunPos.x) / bulletSpeedDecrease;
        float y = (mousePos.y - gunPos.y) / bulletSpeedDecrease;

        player = GameObject.Find("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());


        Vector2 movement = new Vector2(x, y);
        rb2d.velocity = movement;
        DestroyObjectDelayed();


    }

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 5);
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heli"))
        {
            Debug.Log("h");
            player.GetComponent<PlayerController>().AddCount();
            gameObject.SetActive(false);
            Destroy(gameObject, 0);
        }
        
    }
    

    void Update()
    {
        
    }


}
