using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] KeyCode keyCode;

    HingeJoint hJoint;

    float targetPressed;
    float targetRelease;

    void Start()
    {
        hJoint = GetComponent<HingeJoint>();

        targetPressed = hJoint.limits.max;
        targetRelease = hJoint.limits.min;
    }

    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = hJoint.spring;

        if (Input.GetKey(keyCode))
        {
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetRelease;
        }

        hJoint.spring = jointSpring;

    }
}
