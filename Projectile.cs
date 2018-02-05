using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float initialSpeed;

    GameObject target;

    float gravity, delta;

    public float[] GetFiringAngles()
    {
        float[] anglesArray = new float[2];
        
        float verticalDrop = gravity * Mathf.Pow(delta, 2) / (2 * Mathf.Pow(initialSpeed, 2));

        //everything under the radical
        float radical = Mathf.Pow(delta, 2) - 4 * Mathf.Pow(verticalDrop, 2);
        
        //Complete the equation and get our two angles
        float value0 = (-delta + Mathf.Sqrt(radical)) / (2 * verticalDrop);
        float value1 = (-delta - Mathf.Sqrt(radical)) / (2 * verticalDrop);
        
        //add to array
        anglesArray[0] = Mathf.Abs(Mathf.Atan(value0));
        anglesArray[1] = Mathf.Abs(Mathf.Atan(value1));

        //and Done!
        return anglesArray;
    }

    public Vector3 ApplyVelocity(float firingAngle)
    {
        float angle = firingAngle + Mathf.Sin(target.transform.position.y / delta);
        float x = initialSpeed * Mathf.Cos(angle);
        float y = initialSpeed * Mathf.Sin(angle);

        return new Vector3(x, y, 0.0f);
    }

	void Start ()
    {
        target = GameObject.Find("Target");

        gravity = Physics.gravity.y;
        
        delta = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) +
            Mathf.Pow(target.transform.position.y - transform.position.y, 2) +
            Mathf.Pow(target.transform.position.z - transform.position.z, 2));

        float[] anglesList = GetFiringAngles();

        GetComponent<Rigidbody>().velocity = ApplyVelocity(anglesList[0]);
    }
}
