using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] PathCreator pathCreator;
    int totalPath=0;
    int currentPath=0;
    // Start is called before the first frame update
    void Start()
    {
        totalPath = pathCreator.transform.childCount;
        transform.position=getPathPosition(currentPath);
        currentPath++;
    }

    private Vector3 getPathPosition(int i)
    {
        return pathCreator.transform.GetChild(i).transform.position;
    }

    private void Update()
    {
        // Debug.Log(Vector2.Distance(transform.position,getPathPosition(currentPath)));
        if (Vector2.Distance(transform.position,getPathPosition(currentPath))>0)
        {
            transform.position=Vector2.MoveTowards(transform.position,getPathPosition(currentPath),moveSpeed);
        }
        else
        {
            currentPath++;

            if (currentPath>=totalPath)
            {
                currentPath=0;    
            }
        }
    }
}
