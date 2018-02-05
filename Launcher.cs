/* Author Gabriel B. Gallagher January 21, 2018
 * 
 * Script is attached to an empty Game Object at the origin of the scene. Serves as the location from
 * which the projectiles are launched and allows the user to launch them using the space bar
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject projectilePrefab;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, 
                Quaternion.identity) as GameObject;
            projectile.transform.parent = transform;
        }
    }
}
