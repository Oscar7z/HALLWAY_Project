using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    private NavMeshAgent chaser;

    public Animator anim;


    public GameObject Player;

    public float chaserDistanceRun = 4.0f;

    public bool inTrigger;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = true;
        }
        else
        {
            inTrigger = false;
        }
    }


    void Start()
    {
        chaser = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < chaserDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            chaser.SetDestination(newPos);
        }

        if (inTrigger)
        {
            anim.SetBool("Attack", true);
            Debug.Log("entro");
        }


    }

    
}
