using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class Monster: MonoBehaviour
{NavMeshAgent agent;
    Hero targets;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        search();
    }

    void Update()
    {
   agent.SetDestination(targets.transform.position);//move

    }
    void search()
    {
        targets = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();//
    }
    void MonAttack()
    {
        
    }
}
