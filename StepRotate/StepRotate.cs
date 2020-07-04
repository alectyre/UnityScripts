using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepRotate : MonoBehaviour {

    [Tooltip("Degrees per second")] public float speed = 90;
    [Tooltip("Step size in degrees")] public float stepSize = 45;
    public Vector3 axis = Vector3.forward;
	
    float toRotate;

	void Update () 
	{
        toRotate += Time.deltaTime * Mathf.Abs(speed);

        if(stepSize <= 0)
        {
            transform.Rotate(axis, Time.deltaTime * speed);
        }
        else if(speed != 0 && toRotate >= stepSize)
        {
            transform.Rotate(axis, speed > 0 ? stepSize : -stepSize);

            toRotate -= stepSize;
        }
	}
}
