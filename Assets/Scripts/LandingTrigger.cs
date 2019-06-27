using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LandingTrigger : MonoBehaviour
{

    public UnityEvent OnLandEvent;
    // Start is called before the first frame update
    void Start()
    {


        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {

        float vertical = Input.GetAxis("Vertical");
        if (vertical == 0)
        {
            OnLandEvent.Invoke();
        }
    }
}
