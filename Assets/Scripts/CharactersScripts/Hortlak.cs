using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hortlak : MonoBehaviour
{
    Animator anim;
    public float speed;
    public Transform playerObj;
    protected NavMeshAgent agent;
    Vector3 destPoint;
    Rigidbody rb;
    [SerializeField] float range;   // Variable for random destinations range.
    [SerializeField] LayerMask groundLayer;
    bool walkpointSet;     // Variable for making new random destinations.
    bool isRangePlayer = false; // Variable for player is chasing range or not.
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent <Animator>();
    }

    private void Update()
    {

        anim.SetFloat("speed", rb.velocity.magnitude);

        if (!isRangePlayer)
        {
            Patrol();
        }
        else { 
        
            Chase();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { 
        isRangePlayer = true;
        }
    }

    void Chase() {

        if (agent.remainingDistance < 3f)
        {
            anim.SetBool("isAttackRange", true);
        }
        else
        {
           
            anim.SetBool("isAttackRange", false);
            agent.SetDestination(playerObj.position);
        }
       

    }

    void Patrol() { 
    
        if (!walkpointSet)
        {
            SearchForDest();
        }
        if (walkpointSet)
        {
            agent.SetDestination(destPoint);
        }
        if(Vector3.Distance(transform.position, destPoint) < 10) {
            walkpointSet = false;
        }
    }

    void SearchForDest() { 
    
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer)) { 
        
            walkpointSet |= true;
        }
    }
}
