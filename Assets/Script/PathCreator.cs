using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PathCreator : MonoBehaviour
{
    [SerializeField] float pointReduce;       
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;                
        
        foreach (Transform item in transform)
        {
            Gizmos.DrawSphere(item.position,pointReduce);
        }
        
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i+1 < transform.childCount)
            {                
                Gizmos.DrawLine(transform.GetChild(i).position,transform.GetChild(i+1).position);
            }
        }
    }
}
