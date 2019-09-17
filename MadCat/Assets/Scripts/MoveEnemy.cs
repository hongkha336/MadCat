using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

   public float moveSpeed;
    public float timer = 1;
    public float timer2 = 2;
    public Vector3 direction;
    public GameObject obj;
    // Use this for initialization
    public GameObject cat;
    void Start()
    {
        if (cat == null)
            cat = GameObject.FindGameObjectWithTag("Player");
        direction.x = -1;
        direction.y = 0;
            }

    // Update is called once per frame
    void Update()
    {
        timer2 += Time.deltaTime;
        timer += Time.deltaTime;
       
        {
            transform.Translate((direction * Time.deltaTime / 0.4f )*0.5f*moveSpeed);
            timer = 0;
        }
      

    }


    
   
  
}
