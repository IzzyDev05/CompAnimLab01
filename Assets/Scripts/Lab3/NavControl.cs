using System;
using UnityEngine;
using UnityEngine.AI;

public class NavControl : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform faceTarget;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isWalking = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        agent.destination = isWalking ? target.position : transform.position;
        transform.LookAt(faceTarget);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dragon"))
        {
            isWalking = false;
            animator.SetTrigger("attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Dragon"))
        {
            isWalking = true;
            animator.SetTrigger("walk");
        }
    }
}