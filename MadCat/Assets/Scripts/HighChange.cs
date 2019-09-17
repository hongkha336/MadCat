using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighChange : MonoBehaviour {
    public float timer = 0;
    public float timer2 = 2;
    public Vector3 direction;
    public GameObject obj;
    // Use this for initialization
    public GameObject cat;
    void Start()
    {
        if (cat == null)
            cat = GameObject.FindGameObjectWithTag("Player");
        direction.x = 0;
        direction.y = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer2 += Time.deltaTime;
        timer += Time.deltaTime;
        if(timer > 1)
        {
            
            directChange();
            timer = 0;
        }
        {
            transform.Translate((direction * Time.deltaTime / 0.4f) * 0.5f);
            
        }


    }

    void directChange()
    {
        int x = Random.Range(-1, 1);
        if (x>= 0)
            direction.y = -1;
        else
            direction.y =1;
    }
}
