using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSnow : MonoBehaviour
{
    public float speed = 5;
    public float jump = 10;

    private bool isgrounded = false;

    private Animator anim;

    private Vector3 rotation;

    public CoinManagment cm;

    public AudioManager am;

    public GameObject panel;


    public GameObject camera;


    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        cm = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManagment>();
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        if(direction != 0){
            anim.SetBool("IsRunning" , true);

        }else{
            anim.SetBool("IsRunning" , false);
        }


        if(direction < 0){
            transform.eulerAngles = rotation - new Vector3(0,180,0);
            transform.Translate(Vector2.left * speed * direction * Time.deltaTime);
            // transform.Translate(Vector2.right * speed * -direction * Time.deltaTime);


        }
        if(direction > 0 ){
            transform.eulerAngles = rotation ;
                    // ba yek faselei betoore tabi ei jabeja mishe
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
        }

        if(isgrounded == false){
            anim.SetBool("IsJumpping" , true);

        }else{
            anim.SetBool("IsJumpping" , false);
        }



        if(Input.GetKeyDown(KeyCode.Space) && isgrounded){
            //narm bala payin bere = Impulse
            rb.AddForce(Vector2.up * jump , ForceMode2D.Impulse);
            isgrounded = false ;
        }
        

        camera.transform.position = new Vector3(transform.position.x , 0 , -10);
        
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "ground"){
            isgrounded = true ;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {

        // if(other.gameObject.tag == "coin"){
        //     cm.AddMoney();
        //     Destroy(other.gameObject);
        // }

        switch (other.gameObject.tag)
        {
        case "CoinGold":
            am.PlaySound("Coin");
            cm.AddMoneygold();
            Destroy(other.gameObject);
            break;
        case "CoinSilver":
            am.PlaySound("Coin");
            cm.AddMoneysilver();
            Destroy(other.gameObject);
            break;
        case "CoinBronze":
            am.PlaySound("Coin");
            cm.AddMoneybronze();
            Destroy(other.gameObject);
            break;
        }


        if(other.gameObject.tag == "blade"){
            am.PlaySound("enemy");
            panel.SetActive(true);
            Destroy(gameObject);
            cm.moneyReset();
        }

        if(other.gameObject.tag == "enemy"){
            am.PlaySound("enemy");
            panel.SetActive(true);
            Destroy(gameObject);
            cm.moneyReset();
        }

        if(other.gameObject.tag == "finish"){
            // Dynamic Level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }

        if(other.gameObject.tag == "finishGame"){
         SceneManager.LoadScene("Finish");

            // Dynamic Level
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

        }
        
        
    }
}
