using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public static bool doorKey;
    public bool open;
    public bool close;
    public bool inTrigger;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void Update()
    {

        if (inTrigger)
        {
            if (close)
            {
                if (doorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        open = true;
                        close = false;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    open = false;
                    close = true;
                }
            }
        }

        if (open)
        {
            var newRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -90f, 0.0f), Time.deltaTime * 10);
            transform.rotation = newRotation;
        }
        else
        {
            var newRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 10);
            transform.rotation = newRotation;
        }
    }

    void OnGUI()
    {
        if (open)
        {
            GUI.Box(new Rect(0, 0, 250, 25),"Press E to close");
        }
        else
        {
            if (inTrigger && doorKey)
            {
                GUI.Box(new Rect(0, 0, 250, 25), "Press E to open");
            }
            else if (inTrigger)
            {
                GUI.Box(new Rect(0, 0, 250, 25), "Need Key");
            }
        }
    }
}
