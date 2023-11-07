using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;

    bool isWalking = true;
    Animator animator;

    [Header("Speed Control")]

    [Range(0, 10)]
    [SerializeField] float animationSpeed = 1f;

    [Range(0, 10)]
    [SerializeField] float navMeshAgentSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        animator.SetTrigger("WALK");
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = animationSpeed;
        agent.speed = navMeshAgentSpeed;

        if (isWalking)
        {
            agent.destination = target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Target")
        {
            isWalking = false;
            animator.SetTrigger("IDLE");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Target")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}
