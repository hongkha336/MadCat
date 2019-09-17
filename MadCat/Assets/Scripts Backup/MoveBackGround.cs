using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour {

    public double moveRange;
    public int moveSpeed;
    private Vector3 oldPos;
    private GameObject obj;
    // Use this for initialization

    bool isInCenter = false;

    GameObject Cat;


    Animator anim;

    void Start () {
        obj = gameObject;
        oldPos = obj.transform.position;

        if(Cat == null)
        {
            Cat = GameObject.FindGameObjectWithTag("Player");
        }


        anim = Cat.GetComponent<Animator>();
      //  anim.SetBool("isRunnning", false);
    }
	
	// Update is called once per frame
	void Update () {

        //bool inCenter = Cat.GetComponent<PlayerControl>().isInCenterScreen;
        //Debug.Log(inCenter);
        //  if (inCenter)

        isInCenter = Cat.GetComponent<PlayerControl>().isInCenterScreen;
        if (isInCenter)

        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("isRunnning", true);
                obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
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
