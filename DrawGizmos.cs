using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    public enum GIZMOS { ShowOnSelectedGizmo = 0, AlwaysShowGizmo = 1 }
    public GIZMOS showGizmos = GIZMOS.AlwaysShowGizmo;
    public float size = 0.5f;
    public Color color = Color.white;
    public bool show;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = color;
        if (showGizmos == GIZMOS.ShowOnSelectedGizmo)
        {
            Gizmos.DrawWireSphere(transform.position, size);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        if (showGizmos == GIZMOS.AlwaysShowGizmo)
        {
            Gizmos.DrawWireSphere(transform.position, size);
        }
    }
}
