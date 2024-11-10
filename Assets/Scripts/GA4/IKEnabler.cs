using System;
using DitzelGames.FastIK;
using UnityEngine;

public class IKEnabler : MonoBehaviour
{
    [SerializeField] private FastIKFabric leftHand;
    [SerializeField] private FastIKFabric rightHand;
    
    private void Start()
    {
        leftHand.enabled = false;
        rightHand.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            leftHand.enabled = !leftHand.enabled;
            rightHand.enabled = !rightHand.enabled;
        }
    }
}