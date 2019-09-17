using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovewithBG : MonoBehaviour {

    public int moveSpeed;

    private GameObject obj;
    // Use this for initialization

    bool isInCenter = false;

    GameObject Cat;



    // Use this for initialization
    void Start()
    {
        obj = gameObject;


        if (Cat == null)
        {
            Cat = GameObject.FindGameObjectWithTag("Player");
        }

    }

    // Update is called once per frame
    void Update()
    {

        isInCenter = Cat.GetComponent<PlayerControl_bk>().isInCenterScreen;
        if (isInCenter)

        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
             
                obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
            }

        }
    }
}
