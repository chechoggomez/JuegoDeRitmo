using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;
    void Start()
    {
        hasStarted = false;
        beatTempo = beatTempo / 30f;
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
            transform.position = new Vector3(0f, -3.335f * Time.time , 0f);
            //transform.position = transform.position - new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
