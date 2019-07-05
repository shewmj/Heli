using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    private Transform player;
    public GameObject bulletPrefab;
    private Vector3 offset;
    private bool facingRight;
    private int maxShots;
    private int shots;

    // Start is called before the first frame update
    void Start()
    {

        shots = 0;
        player = transform.parent.transform;
        facingRight = true;
        offset = transform.position - player.position;

        switch(gameObject.tag)
        {
            case "AK47":
                maxShots = 10;
                break;
            default:
                maxShots = int.MaxValue;
                break;

        }
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
        shots++;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        if(shots >= maxShots)
        {
            DestroyObject();
        }
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

    


    private void DestroyObject()
    {
        gameObject.SetActive(false);
        transform.parent.GetComponent<PlayerController>().ResetWeapon();
        Destroy(gameObject, 0);
    }


    

}
