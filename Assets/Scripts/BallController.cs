using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocityX=10f;
    private Rigidbody2D rigidbody;
   // public GameObject rightBullet;
    private PlayerController playerController;    
    public int vidaEnemy = 5;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>(); //lo busca
        //para eliminar gameobject
        Destroy(gameObject,4);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = Vector2.right * velocityX;
    }
    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.layer == 7 ){
            /*vidaEnemy--;
            if(vidaEnemy==3){*/
                 Debug.Log("Entra");
                Destroy(other.gameObject);
                Destroy(this.gameObject);
           // }
           // Destroy(this.gameObject);
            
             Debug.Log("fuera"+vidaEnemy);
           // playerController.AumentaScore10();
        }
      
    }
}
