using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{    
    public class PacmanMovement : MonoBehaviour
    {
        [SerializeField] float moveSpeed=0.04f;

        private Rigidbody2D myRd;
        private Vector2 destination=Vector2.zero;
        private Vector2 direction=Vector2.zero;
        private Vector2 nextDestination=Vector2.zero;

        private void Awake()
        {
            myRd=GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            destination=transform.position;
        }
        private void FixedUpdate()
        {
            Movement();
        }
        private bool isValideDirection(Vector2 dir)
        {
            Vector2 pos=transform.position;

            dir+=new Vector2(dir.x*0.05f,dir.y*0.05f);

            RaycastHit2D hit=Physics2D.Linecast(pos+dir,pos);

            if (hit.collider!=null)
            {                
                if (hit.collider.CompareTag("maze"))
                {
                    return false;
                }
                else
                {
                    return true;
                }                
            }
            else
            {
                return true;
            }
        }

        private void Movement()
        {
            Vector2 pos=Vector2.MoveTowards(transform.position,destination,moveSpeed);
            myRd.MovePosition(pos);
             
            if (Input.GetAxis("Horizontal")>0)
            {
                nextDestination=Vector2.right;
            }
            
            if (Input.GetAxis("Horizontal")<0)
            {
                nextDestination=Vector2.left;
            }
            
            if (Input.GetAxis("Vertical")>0)
            {
                nextDestination=Vector2.up;
            }
            
            if (Input.GetAxis("Vertical")<0)
            {
                nextDestination=Vector2.down;
            }
            Debug.Log(Vector2.Distance(destination, transform.position) < 0.0000001f);
            if (Vector2.Distance(destination,transform.position)<0.0000001f)
            {
                if (isValideDirection(nextDestination))
                {
                    destination=(Vector2)transform.position+nextDestination;
                    direction=nextDestination; 
                }
                else if(isValideDirection(direction))
                {
                    destination=(Vector2)transform.position+direction;
                }
            }
        }
    }
}
