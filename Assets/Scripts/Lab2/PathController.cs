using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PathController : MonoBehaviour
{
    [SerializeField] private PathManager pathManager;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform raycastStartPos;
    [SerializeField] private float obstacleCheckDistance = 2.5f;
    
    private List<Waypoint> thePath;
    private Waypoint target;
    private bool isWalking;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isWalking = false;
        animator.SetBool("isWalking", isWalking);

        thePath = pathManager.GetPath();
        if (thePath != null && thePath.Count > 0)
        {
            target = thePath[0];
        }
    }

    private void RotateTowardTarget()
    {
        float stepSize = rotateSpeed * Time.deltaTime;

        Vector3 targetDir = target.GetPos() - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void MoveForward()
    {
        float stepSize = Time.deltaTime * moveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, target.GetPos());

        if (distanceToTarget < stepSize) return;

        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir * stepSize);
    }
    
    void Update()
    {
        CheckForObstacles();

        if (Input.anyKeyDown)
        {
            isWalking = !isWalking;
            animator.SetBool("isWalking", isWalking);
        }

        if (isWalking)
        {
            RotateTowardTarget();
            MoveForward();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        target = pathManager.GetNextTarget();
    }

    private void CheckForObstacles()
    {
        RaycastHit hit;

        if (Physics.Raycast(raycastStartPos.position, transform.forward, out hit, obstacleCheckDistance))
        {
            print("Hit: " + hit.collider.name);
            isWalking = false;
            animator.SetBool("isWalking", isWalking);
        }
        else
        {
            isWalking = true;
            animator.SetBool("isWalking", isWalking);
        }
    }
}