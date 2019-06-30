using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    
    private Vector3 offset;
    private Rigidbody2D rb2d;
    public int bulletSpeedDecrease;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, 90f, Space.Self);

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
        float x = (mousePos.x - gunPos.x) / bulletSpeedDecrease;
        float y = (mousePos.y - gunPos.y) / bulletSpeedDecrease;

       

        Vector2 movement = new Vector2(x, y);
        rb2d.velocity = movement;
        DestroyObjectDelayed();


    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        



        //Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //aimPos.z = 0;



        
    }
}
