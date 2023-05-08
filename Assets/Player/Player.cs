using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    

    public float moveSpeed = 15.0f;
    
    public GameObject respawnPoint;

    private CharacterController controller;

    public float fixedYPosition = 3.81f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-horizontalInput, 0.0f, -verticalInput);

        controller.Move(movement * moveSpeed * Time.deltaTime);


        transform.position = new Vector3(transform.position.x, fixedYPosition, transform.position.z);

        
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        
    }


    public void reset(){
        Debug.Log("Reset Player");
        transform.position = respawnPoint.transform.position;
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        
    }

  


}
