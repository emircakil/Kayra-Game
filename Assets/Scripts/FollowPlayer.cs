using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerObj;
    protected NavMeshAgent monsterMesh;
    void Start()
    {
        monsterMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        monsterMesh.SetDestination(playerObj.position);

    }
}
