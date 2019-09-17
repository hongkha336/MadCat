using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


    private GameObject obj;
    public float FlayPower;
    bool isFly;
    public int moveSpeed;
    

    
    
    Animator anim;

    public bool isInCenterScreen = false;
	// Use this for initialization
	void Start () {
        obj = gameObject;
        isFly = false;
        moveSpeed = 3;
        isInCenterScreen = false;

        anim = obj.GetComponent<Animator>();


        anim.SetBool("isRunnning", false);
        anim.SetBool("IsFight", false);


    
	}

    bool isBack = true;

	// Update is called once per frame
	void Update () {
        //Bay



        if (Input.GetKey(KeyCode.UpArrow) && !isFly)
        {
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FlayPower));
            isFly = true;


        }
        else
        {
            // chạy qua phải
            if (Input.GetKey(KeyCode.RightArrow) && !isInCenterScreen)
            {

                if (!isBack)
                {
                    obj.transform.localScale = new Vector3(-1 * obj.transform.localScale.x, obj.transform.localScale.y, 0);
                    isBack = true;
                }

                obj.transform.Translate(new Vector3(1 * Time.deltaTime * (moveSpeed), 0, 0));

                anim.SetBool("isRunnning", true);
                return;

            }
            else
            {
                // chạy qua trái
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (isBack)
                    {
                        obj.transform.localScale = new Vector3(-1 * obj.transform.localScale.x, obj.transform.localScale.y, 0);
                        isBack = false;
                    }
                    obj.transform.Translate(new Vector3(-1 * Time.deltaTime * (moveSpeed), 0, 0));
                    anim.SetBool("isRunnning", true);

                }
                else
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        anim.SetBool("IsFight", true);
                    }
                    else
                    {
                        anim.SetBool("isRunnning", false);
                        anim.SetBool("IsFight", false);
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.tag.Equals("Untagged") && !other.gameObject.tag.Equals("Center"))
        {
            isFly = false;
        


        }
        if (other.gameObject.tag.Equals("Center"))
            isInCenterScreen = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Center"))
            isInCenterScreen = false;
    }
 
   
}
