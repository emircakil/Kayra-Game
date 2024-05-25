using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class Crawler : MonoBehaviour
{
    Animator anim;
    [SerializeField] Transform playerObj;
    NavMeshAgent agent;
    Rigidbody rb;
    bool isRangedPlayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(isRangedPlayer)
        {
            Chase();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { 
        
            isRangedPlayer = true;

        }
    }

    void Chase() {

        float dis = Vector3.Distance(this.transform.position, playerObj.position);

        Vector3 direction = this.transform.position - transform.position;
        direction.Normalize();
        Vector3 newPosition = playerObj.transform.position + (direction * 15f);

        if (dis <= 2.5f)
        {


        }
        else { 
        
            agent.SetDestination(newPosition);
        }
        RotateTowardsTarget();
    }
    void RotateTowardsTarget()
    {
       Vector3 direction = (playerObj.transform.position - transform.position).normalized;
       Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z-90));
       transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }
}
