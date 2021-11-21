using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public  float beatTempo;
    private float speed; 

    public bool hasStarted;
    void Start()
    {
        hasStarted = false;

        speed = beatTempo / 32.697f;
        transform.position = new Vector3(0f, -6.42f , 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            /*if(Input.anyKeyDown)
            {
                hasStarted = true;
            }*/
        }else
        {
            transform.position = transform.position - new Vector3(0f, speed * Time.deltaTime , 0f);
        }
    }
}
