using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownControl : MonoBehaviour {
    public float moveSpeed;
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
        direction.y = -1;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        {
            transform.Translate((direction * Time.deltaTime / 0.4f) * 0.5f* moveSpeed);

        }


    }

    public void setMoveSpeed(float i)
    {
        moveSpeed = i;
    }

   
}
