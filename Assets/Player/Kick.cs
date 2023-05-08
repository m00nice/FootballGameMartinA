using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public float kickSpeed = 1000.0f;
    public bool isKicking = false;
    private float totalRotation = 0.0f;
    public Transform targetObject;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        //KICK STUFF
        if(Input.GetMouseButton(0)){
            isKicking = true;
        }

        if(Input.GetMouseButton(1)){
            transform.LookAt(targetObject);

        }

        if(Input.GetKeyDown(KeyCode.Space)){
            transform.rotation = Quaternion.identity;
            transform.Rotate(0, 180, 0);
        }

       if(isKicking){

        float rotationAmount = kickSpeed * Time.deltaTime;
            transform.Rotate(Vector3.left, rotationAmount);
            totalRotation += rotationAmount;

        if (totalRotation >= 360.0f)
        {
            isKicking = false;
            transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
            totalRotation = 0.0f;
        }

        



        

    }






    }
}
