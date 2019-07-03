using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public Transform player;
    public GameObject bulletPrefab;
    private Vector3 offset;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - gunPos.x;
        mousePos.y = mousePos.y - gunPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.position = player.position + offset;

        //Debug.Log("z: " + transform.eulerAngles.z);
        float rotation = transform.eulerAngles.z;
        if (rotation > 90 && rotation < 270 && facingRight)
        {
            Flip();
        } else if((rotation <= 90 || rotation >= 270) && !facingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


    }


    private void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        theScale.y *= -1;
        transform.localScale = theScale;
    }

    
    public void UnFlip()
    {
        //facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        //theScale.y *= -1;
        transform.localScale = theScale;
    }
    




}
