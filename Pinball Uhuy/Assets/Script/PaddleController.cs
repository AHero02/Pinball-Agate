using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public KeyCode input;

    //  Untuk menyimpan Hinge Joint
    private HingeJoint hinge;
    public float springPower;
    public float flipperDamper;

    //  Simpanan Target
    public float targetPressed;
    public float targetReleased;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;

        //targetPressed = hinge.limits.max;
        //targetReleased = hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }


    private void ReadInput()
    {

        //  Langsung menggunakan variabel yang sudah dibuat saat Start
        JointSpring jointSpring = new JointSpring();
            jointSpring.spring = springPower;
        jointSpring.damper = flipperDamper;

        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed;
            Debug.Log("Push Paddle button");
        }
        else
        {
            //jointSpring.spring = 0;
            jointSpring.targetPosition = targetReleased;
        }

        hinge.spring = jointSpring;
        hinge.useLimits = true;
    }
}
