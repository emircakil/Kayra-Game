using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class HortlakAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float distance = 1.5f;
    Animator anim;
    public Transform playerObj;
    NavMeshAgent agent;
    Rigidbody rb;
    bool isRangePlayer = false; // Variable for player is chasing range or not.
    int targetPoint;
    AudioSource audioSource;
    public AudioClip detectSound;
    public AudioClip biteSound;

    bool isPlayerRanged = false;
    bool hasDetectPlayed = false;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        targetPoint = 0;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position == patrolPoints[targetPoint].position) {

            increaseTarget();
        }

        anim.SetFloat("speed", rb.velocity.magnitude);

        if (!isRangePlayer)
        {
            Patrol();
        }
        else
        {

            Chase();
        }

        if (isPlayerRanged && !hasDetectPlayed) {
            hasDetectPlayed = true;
            audioSource.clip = detectSound;
            audioSource.Play();
        }


    }

    void Patrol() { 
    
        if (agent.remainingDistance < 2f)
        {
            increaseTarget();
            RotateTowardsTarget();
        }

        agent.SetDestination(patrolPoints[targetPoint].position);
    }

    void Chase() {

        float dis = Vector3.Distance(this.gameObject.transform.position, playerObj.position);


        Vector3 direction = this.transform.position - playerObj.transform.position;
        direction.Normalize();
        Vector3 newPosition = playerObj.transform.position + direction * (distance);

    
      

        if (dis <= 2.5f)
        {
            anim.SetBool("isAttackRange", true);
         
        }
        else
        {
            anim.SetBool("isAttackRange", false);
            agent.SetDestination(newPosition);
        }

        
        RotateTowardsTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isRangePlayer = true;
            agent.speed = 4.5f;
            isPlayerRanged = true;
        }
    }


    void RotateTowardsTarget()
    {
        if (!isRangePlayer)
        {
            Vector3 direction = (patrolPoints[targetPoint].position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }
       
    }

    void increaseTarget() {

        targetPoint++;
        if(targetPoint >= patrolPoints.Length) {
            targetPoint = 0;

        }
    }
}
