using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround_bk : MonoBehaviour {

    public double moveRange;
    public int moveSpeed;
   public  Vector3 oldPos;
    private GameObject obj;
    // Use this for initialization
    private GameObject controller;
   public bool isInCenter = false;

    GameObject Cat;



    Animator anim;

    void Start()
    {
        obj = gameObject;
        oldPos = obj.transform.position;

        if (Cat == null)
        {
            Cat = GameObject.FindGameObjectWithTag("Player");
        }

        if(controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("controller");
        }

        anim = Cat.GetComponent<Animator>();
        //  anim.SetBool("isRunnning", false);
    }

    // Update is called once per frame
    void Update()
    {

        //bool inCenter = Cat.GetComponent<PlayerControl>().isInCenterScreen;
        //Debug.Log(inCenter);
        //  if (inCenter)

        isInCenter = Cat.GetComponent<PlayerControl_bk>().isInCenterScreen;
        if (isInCenter)

        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("isRunnning", true);
                obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
                controller.GetComponent<GamePlayControl>().run(0.1f);

            }
            else
                anim.SetBool("isRunnning", false);

            if (Vector3.Distance(oldPos, obj.transform.position) > moveRange)
            {
                obj.transform.position = oldPos;
            }

        }

    }

 

}
