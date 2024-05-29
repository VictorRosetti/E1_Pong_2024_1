using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
