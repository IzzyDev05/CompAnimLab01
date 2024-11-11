using System;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform leftHandTarget;
    [SerializeField] private float lerpSpeed;

    private void Update()
    {
        float i = 0f;
        float rate = 1f / lerpSpeed;
        
        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            leftHand.position = Vector3.Lerp(leftHand.position, leftHandTarget.position, i);
        }
    }
}
