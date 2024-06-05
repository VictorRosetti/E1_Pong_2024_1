using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed = 10;
    public TMP_Text pointsLeft;
    public TMP_Text pointsRight;
    public Camera mainCam;
    public GameObject power;
    public Camera secondCam;
    int playerA_points=0;
    int playerB_points=0;
    // Start is called before the first frame update
    public GameObject prefab;

    public bool isPaused=false;
    void Start()
    {
        if((playerA_points>=3)||(playerB_points>=3))
        {
            SceneManager.LoadScene(2);
        }
        float x = Random.Range(0,2) == 0 ? -1:1;
        /*
        float x = Random.Range(0,2); 0..1
        if(x == 0)
        {
            x = -1;
        }else
        {
            x = 1;
        }
        */
        float y = Random.Range(0,2)==0? -1:1;
        GetComponent<Rigidbody>().velocity = new Vector2(speed*x, speed*y);
        pointsLeft.SetText(playerA_points.ToString());
        pointsRight.SetText(playerB_points.ToString());
        for(int i=0;i<5;i++)
        {
            Instantiate(prefab,new Vector3(-16+i, 0, 0), Quaternion.identity); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Pause();
        }
        
    }

    void OnCollisionEnter(Collision hit)
    {
        GetComponent<AudioSource>().Play();
        if(hit.gameObject.name=="Left")
        {
            transform.position = new Vector3(0,3,0);
            playerB_points++;
            Start();
        }else if(hit.gameObject.name=="Right")
        {
            transform.position=new Vector3(0,3,0);
            playerA_points++;
            Start();
        }else if(hit.gameObject.tag=="PowerUp")
        {
            //mainCam.fieldOfView = 147;
            mainCam.enabled=false;
            secondCam.enabled=true;
            //Instantiate(prefab,new Vector3(-16, 0, 0), Quaternion.identity); 
            //Destroy(power);
            power.SetActive(false);
            StartCoroutine(PowerEnd(5));
        }
    }

    void OnTriggerEnter(Collider touch)
    {
        if(touch.gameObject.name=="PowerUp2")
        {
            mainCam.fieldOfView = 60;
            touch.gameObject.SetActive(false);
            //Destroy(touch.gameObject);
        }
    }

    IEnumerator PowerEnd(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        //mainCam.fieldOfView = 60;
        mainCam.enabled = true;
        secondCam.enabled = false;
    }

    void Pause(){
        if(isPaused)
        {
            Time.timeScale = 0;
        }else
        {
            Time.timeScale = 1;
        }
    }
}
