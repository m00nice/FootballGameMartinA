using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalie : MonoBehaviour
{

    

    public GameObject respawnPoint;

    public Transform pointA;
    public Transform pointB;

    public bool isSpinning = false;

    public float moveSpeed = 1.0f;

    public float fixedYPosition = 5.05f;

    public float rotationSpeed = 150.0f;
    //spin z axis

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpinning){
        float t = Mathf.PingPong(Time.time * moveSpeed, 1f);
        transform.position = Vector3.Lerp(pointA.position, pointB.position, t);

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, fixedYPosition, transform.position.z);
        }
    }

    public void reset(){
        transform.position = respawnPoint.transform.position;
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }


}
