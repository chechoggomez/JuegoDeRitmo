using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool isPressed;
    public bool canBePressed;
    public KeyCode keyToPress;
   

  
    void Start()
    {
        isPressed = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                isPressed = true;
                gameObject.SetActive(false);
                //GameManager.instance.NoteHit();
                
                if(Mathf.Abs(transform.position.y) > 0.40)
                {
                    GameManager.instance.NormaltHit();
                } else if (Mathf.Abs(transform.position.y) > 0.20)
                {
                    GameManager.instance.GoodtHit();
                } else 
                {
                    GameManager.instance.PerfectHit();
                
                }



            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
            Debug.Log("canBePressed");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            if (isPressed == false)
            {
                GameManager.instance.NoteMissed();

            }
            
        }
    }
}
