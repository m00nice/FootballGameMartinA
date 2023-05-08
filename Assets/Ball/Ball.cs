using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    
    public Rigidbody rb;

    public GameObject respawnPoint;

    public GameObject player;

    public GameObject game;

    public GameObject defence;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        player = GameObject.Find("Player");
        game = GameObject.Find("Game");
        defence = GameObject.Find("Defence");
    }


    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.GetComponent<Rigidbody>() != null){
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Kick>().isKicking){
            Vector3 awayFromCollision = transform.position - collision.contacts[0].point;
            awayFromCollision = awayFromCollision.normalized * 8f;
            rb.AddForce(awayFromCollision, ForceMode.Impulse);
        }else if(collision.gameObject.CompareTag("Player")){
            Vector3 awayFromCollision = transform.position - collision.contacts[0].point;
            awayFromCollision = awayFromCollision.normalized * 1f;
            rb.AddForce(awayFromCollision, ForceMode.Impulse);
        }
        
        if(collision.gameObject.CompareTag("Enemy")){
            // + ball intercepted
            reset();
            game.GetComponent<Game>().ballInterceptedadd();
        }
        
    }
    if(collision.gameObject.CompareTag("Pole")){
            Vector3 awayFromCollision = transform.position - collision.contacts[0].point;
            awayFromCollision = awayFromCollision.normalized * 20f;
            rb.AddForce(awayFromCollision, ForceMode.Impulse);
        }
    if(collision.gameObject.tag == "Bound"){
            // + ball out a bounds
            reset();
            game.GetComponent<Game>().OOBadd();
        }
    }


    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Goal"){
            //Score Goal
            Debug.Log("GOOOOOOOOOOOOOOAAAAAAAAAAAAAAAALLLLLLL");

            reset();
            game.GetComponent<Game>().goalsAdd();
            
        }
        

    }

    void reset(){
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = respawnPoint.transform.position;
        if(player != null){
        player.GetComponent<Player>().reset();
        }else{Debug.Log("player null");}
        if(defence  != null){
        defence.GetComponent<Defence>().reset();
        }else{Debug.Log("defence null");}
        Debug.Log("reset Ball");
    }


}
