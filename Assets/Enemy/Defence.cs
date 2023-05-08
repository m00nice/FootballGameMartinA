using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{

    

    public float moveSpeed = 7.0f;

    public float fixedYPosition = 3.81f;

    public Transform targetObject;

    public GameObject respawnPoint1;

    public GameObject respawnPoint2;

    public GameObject respawnPoint3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        transform.LookAt(targetObject);

        transform.Translate((Vector3.forward + new Vector3(0, 0, 0)) * Time.deltaTime * moveSpeed);

        
        transform.position = new Vector3(transform.position.x, fixedYPosition, transform.position.z);

        
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        
    }


    public void reset(){
        int randomNum = Random.Range(1,4);
        Debug.Log("Reset Defence "+randomNum);
        if(randomNum == 1){
        transform.position = respawnPoint1.transform.position;
        }
        if(randomNum == 2){
        transform.position = respawnPoint2.transform.position;
        }
        if(randomNum == 3){
        transform.position = respawnPoint3.transform.position;
        }
    }


}
