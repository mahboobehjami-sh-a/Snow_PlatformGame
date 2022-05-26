using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnow : MonoBehaviour
{
    public float speed = 5;
    public float jump = 10;

    private bool isgrounded = false;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        // ba yek faselei betoore tabiei jabeja mishe
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);


        if(Input.GetKeyDown(KeyCode.Space) && isgrounded){
            //narm bala payin bere = Impulse
            rb.AddForce(Vector2.up * jump , ForceMode2D.Impulse);
            isgrounded = false ;
        }
        
        
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "ground"){
            isgrounded = true ;
        }
    }
}
