using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LandingTrigger : MonoBehaviour
{


    public UnityEvent OnLandEvent;
    private bool topJump;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        topJump = false;
        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (rb2d.velocity.y < 0)
        {
            topJump = true;
        }
        if (rb2d.velocity.y == 0 && topJump)
        {
            topJump = false;
            OnLandEvent.Invoke();
        }
    }
}
