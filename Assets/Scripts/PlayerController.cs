using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool estaTocandoElSuelo = false;
    private float speed = 10;
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
     private Animator animator;
     public GameObject rightBullet;

     public GameObject rightBulletM;
    public GameObject leftBullet;

    // Start is called before the first frame update
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
       animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.X))
        {
           //
            if(!sr.flipX)
            {
            var position = new Vector2(transform.position.x+0.8f,transform.position.y+0.1f);
                Instantiate(rightBullet,position,rightBullet.transform.rotation);
            }
            else{
             var position = new Vector2(transform.position.x-2f,transform.position.y-0.5f);
                Instantiate(leftBullet,position,rightBullet.transform.rotation);
            }
            //audioSource.PlayOneShot(audioClips[1]);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
           //
            if(!sr.flipX)
            {
            var position = new Vector2(transform.position.x+0.8f,transform.position.y+0.1f);
                Instantiate(rightBulletM,position,rightBulletM.transform.rotation);
            }
            else{
             var position = new Vector2(transform.position.x-2f,transform.position.y-0.5f);
                Instantiate(leftBullet,position,rightBulletM.transform.rotation);
            }
            //audioSource.PlayOneShot(audioClips[1]);
        }


        if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            run();
            
            rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            run();
            rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
        }else
        {
            SetIdleAnimation();
            rb2d.velocity = new Vector2(0,rb2d.velocity.y);
        }
        if(Input.GetKeyDown(KeyCode.Space) && estaTocandoElSuelo){
            
            saltar();
            estaTocandoElSuelo = false;
            
            // rb2d.velocity = new Vector2(rb2d.velocity.x,10);
            
            //rb2d.AddForce(new Vector2(0,1000));
         }
    }
    public void saltar(){
        var upSpeed = 80f;
        SetJumpAnimation();
        rb2d.velocity = Vector2.up * upSpeed;
        
       // audioSource.PlayOneShot(audioClips[0]);
        
    }
      void OnCollisionEnter2D(Collision2D other){
         if(other.gameObject.layer == 6)
             estaTocandoElSuelo = true;
      }
    public void run(){
        animator.SetInteger("Estado", 3);
    }
    public void SetRunDisAnimation(){
        animator.SetInteger("Estado", 2);
    }
    public void SetJumpAnimation(){
        animator.SetInteger("Estado", 1);
    }
    public void SetIdleAnimation(){
        animator.SetInteger("Estado", 0);        
    }
    
}
