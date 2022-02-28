using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PacmanMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem collectParticleSystem=null;
    [SerializeField] ParticleSystem gameoverParticleSystem=null;

    [SerializeField] UnityEvent GameOverEvent;
    [SerializeField] TextMeshProUGUI gameoverText;
    
    private Vector2 tempMove=Vector2.zero;
    private int itemCount=0;
    private bool isGameOver=false;
   
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isGameOver)
        {
            
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale=new Vector3(1,1,1);
                transform.eulerAngles=new Vector3(0,0,0);
                tempMove=Vector2.right;            
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localScale=new Vector3(-1,1,1);
                transform.eulerAngles=new Vector3(0,0,0);
                tempMove = Vector2.left;            
            }

            if (Input.GetAxis("Vertical") > 0)
            {
                transform.localScale=new Vector3(1,1,1);
                transform.eulerAngles=new Vector3(0,0,90);
                tempMove = Vector2.up;            
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                transform.localScale=new Vector3(1,1,1);
                transform.eulerAngles=new Vector3(0,0,-90);
                tempMove = Vector2.down;            
            }

            transform.position += (Vector3)tempMove * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("item") && !isGameOver)
        {
            //play particle system
            collectParticleSystem.gameObject.transform.position=other.transform.position;
            collectParticleSystem.Play();
            itemCount++;
            if (itemCount>=5)
            {
                //gameover
                gameoverText.text="Congratulations";
                isGameOver=true;
                GameOverEvent.Invoke();
                gameoverParticleSystem.Play();
            }           
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("enemy") && !isGameOver)
        {
            //gameover
            isGameOver=true;
            gameoverText.text="GameOver";
            GameOverEvent.Invoke();            
        }
    }
}
