using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSky : MonoBehaviour {

    public double moveRange;
    public int moveSpeed;
    private Vector3 oldPos;
    private GameObject obj;



    void Start()
    {
        obj = gameObject;
        oldPos = obj.transform.position;

  

    }

    // Update is called once per frame
    void Update()
    {


                obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
         

            if (Vector3.Distance(oldPos, obj.transform.position) > moveRange)
            {
                obj.transform.position = oldPos;
            }

        

    }
}
