using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{

    public float roundTime = 0.0f;
    public float gameScore = 0.0f;
    public float ballIntercepted = 0.0f;
    public float ballsOutOfBound = 0.0f;
    public bool isRound = false;

    public GameObject goals;
    public GameObject intercept;
    public GameObject OOB;
    public GameObject timer;


    public Button level1;
    public Button level2;
    public Button level3;
    public Button exit;

    public GameObject player;

    public GameObject defence;

    public GameObject goalie;

    public Camera cameraMenu;

    public Camera cameraGame;    

    public AudioClip audioWhistle;

    public AudioClip audioGoal;

    public AudioSource audioSource;

    public AudioClip level1ST;

    public AudioClip level2ST;

    public AudioClip level3ST;

    public AudioSource soundTrack;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        goalie = GameObject.Find("Goalie");
        defence = GameObject.Find("Defence");

        level1.onClick.AddListener(StartRound1);
        level2.onClick.AddListener(StartRound2);
        level3.onClick.AddListener(StartRound3);

        exit.onClick.AddListener(exitApp);

        menu();

    }

    // Update is called once per frame
    void Update()
    {
        goals.GetComponent<TextMeshProUGUI>().text = "Goals: "+gameScore;
        intercept.GetComponent<TextMeshProUGUI>().text = "intercepted: "+ballIntercepted;
        OOB.GetComponent<TextMeshProUGUI>().text = "Out of bounds: "+ballsOutOfBound;

        float timeInSecs = Time.time-roundTime;

        int minutes = Mathf.FloorToInt(timeInSecs / 60);
        int seconds = Mathf.FloorToInt(timeInSecs % 60);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timer.GetComponent<TextMeshProUGUI>().text = timeString;

        if(Input.GetKeyDown(KeyCode.Escape)){
            menu();
        }


    }


    void menu(){

        soundTrack.Stop();

        

        player.SetActive(false);
        defence.SetActive(false);
        goalie.SetActive(false);
        

        
        cameraGame.gameObject.SetActive(false);
        cameraMenu.gameObject.SetActive(true);

        roundTime = 0.0f;
        
        level1.gameObject.SetActive(true);
        level2.gameObject.SetActive(true);
        level3.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);

        goals.gameObject.SetActive(false);
        intercept.gameObject.SetActive(false);
        OOB.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);


    }

    void StartRound1(){

        soundTrack.clip = level1ST;
        soundTrack.loop = true;
        soundTrack.Play();

        roundTime = Time.time;

        cameraMenu.gameObject.SetActive(false);
        cameraGame.gameObject.SetActive(true);
        
        audioSource.PlayOneShot(audioWhistle);

        player.SetActive(true);
        player.GetComponent<Player>().reset();

        defence.SetActive(false);
        defence.GetComponent<Defence>().reset();

        goalie.SetActive(false);
        goalie.GetComponent<Goalie>().reset();

        
        gameScore = 0.0f;
        ballIntercepted = 0.0f;
        ballsOutOfBound = 0.0f;

        
        level1.gameObject.SetActive(false);
        level2.gameObject.SetActive(false);
        level3.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);

        goals.gameObject.SetActive(true);
        intercept.gameObject.SetActive(true);
        OOB.gameObject.SetActive(true);
        timer.gameObject.SetActive(true);
    }

    void StartRound2(){

        soundTrack.clip = level2ST;
        soundTrack.loop = true;
        soundTrack.Play();

        roundTime = Time.time;

        cameraMenu.gameObject.SetActive(false);
        cameraGame.gameObject.SetActive(true);

        audioSource.PlayOneShot(audioWhistle);

        player.SetActive(true);
        player.GetComponent<Player>().reset();

        defence.SetActive(true);
        defence.GetComponent<Defence>().moveSpeed = 7f;
        defence.GetComponent<Defence>().reset();

        goalie.SetActive(true);
        goalie.GetComponent<Goalie>().isSpinning = false;
        goalie.GetComponent<Goalie>().reset();

        
        gameScore = 0.0f;
        ballIntercepted = 0.0f;
        ballsOutOfBound = 0.0f;

        
        level1.gameObject.SetActive(false);
        level2.gameObject.SetActive(false);
        level3.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);

        goals.gameObject.SetActive(true);
        intercept.gameObject.SetActive(true);
        OOB.gameObject.SetActive(true);
        timer.gameObject.SetActive(true);

    }

    void StartRound3(){

        

        soundTrack.clip = level3ST;
        soundTrack.loop = true;
        soundTrack.Play();
        
        roundTime = Time.time;
        
        cameraMenu.gameObject.SetActive(false);
        cameraGame.gameObject.SetActive(true);
        
        audioSource.PlayOneShot(audioWhistle);
    
        player.SetActive(true);
        player.GetComponent<Player>().reset();

        defence.SetActive(true);
        defence.GetComponent<Defence>().moveSpeed = 10f;
        defence.GetComponent<Defence>().reset();

        goalie.SetActive(true);
        goalie.GetComponent<Goalie>().isSpinning = true;
        goalie.GetComponent<Goalie>().reset();

        
        gameScore = 0.0f;
        ballIntercepted = 0.0f;
        ballsOutOfBound = 0.0f;

        
        level1.gameObject.SetActive(false);
        level2.gameObject.SetActive(false);
        level3.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);

        goals.gameObject.SetActive(true);
        intercept.gameObject.SetActive(true);
        OOB.gameObject.SetActive(true);
        timer.gameObject.SetActive(true);



    }



    public void ballInterceptedadd(){
        ballIntercepted = ballIntercepted + 1;
    }

    public void goalsAdd(){
        gameScore = gameScore + 1;
        audioSource.PlayOneShot(audioGoal);
    }

    public void OOBadd(){
        ballsOutOfBound = ballsOutOfBound + 1;
    }





    private void exitApp(){
        Application.Quit();       
    }




}
