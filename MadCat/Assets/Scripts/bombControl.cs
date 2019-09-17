using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombControl : MonoBehaviour {

    // Use this for initialization
    public GameObject obj;
    public Animator anim;
    public GameObject Cat;
	void Start () {
        obj = gameObject;
        anim = obj.GetComponent<Animator>();
        anim.SetBool("isExplore", false);

        isBoom = false;
        if (Cat == null)
        Cat = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
		if(isBoom)
        {
            timerBoom += Time.time;
        }
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("noThing"))
        {



            if (other.gameObject.tag.Equals("Player") && timerBoom == 0)
            {

                Cat.GetComponent<PlayerControl_bk>().killLife(50);
                anim.SetBool("isExplore", true);
                Debug.Log("Bom cham Collision");
                isBoom = true;

            }
            else
            {
                anim.SetBool("isExplore", true);
                isBoom = true;
            }


            //  obj.transform.localScale = new Vector3(5 * obj.transform.localScale.x, 5 * obj.transform.localScale.y, 0);
            Destroy(obj, 0.2f);
            if (timerBoom > 1)
            {
                isBoom = false;
                timerBoom = 0;
            }
            Debug.Log(other.gameObject.tag);
        }
    }
   public bool isBoom = false;
   public float timerBoom = 0;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.tag.Equals("noThing") )
        {
          

          
            if (other.gameObject.tag.Equals("Player") && !isBoom )
            {

                Cat.GetComponent<PlayerControl_bk>().killLife(20);
                anim.SetBool("isExplore", true);
                Debug.Log("Bom cham Collision");
                isBoom = true;

            }
            else
            {
                anim.SetBool("isExplore", true);
                isBoom = true;
            }
         

            //  obj.transform.localScale = new Vector3(5 * obj.transform.localScale.x, 5 * obj.transform.localScale.y, 0);
            Destroy(obj, 0.2f);
           if(timerBoom > 1)
            {
                isBoom = false;
                timerBoom = 0;
            }
            Debug.Log(other.gameObject.tag);
        }
    }
}
