using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliController : MonoBehaviour
{

    private GameObject player;
    private bool dropped;
    public GameObject ak47pickup;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        dropped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerController>().count > 10 && !dropped)
        {
            dropped = true;
            Instantiate(ak47pickup, transform.position, transform.rotation);
        }
    }
}
