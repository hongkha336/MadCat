using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour {


    public int moveSpeed;
    public float oldPos;
    private GameObject obj;
    private Vector3 oldRockPos;
    bool isInCenter = false;
    // Use this for initialization
    GameObject Cat;

    Animator anim;
    void Start()
    {
        obj = gameObject;
        if (obj.gameObject.tag.Equals("Rock"))
            oldRockPos = obj.transform.position;

        if (Cat == null)
        {
            Cat = GameObject.FindGameObjectWithTag("Player");
        }

        anim = Cat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag.Equals("Reset"))
        {

            if (obj.gameObject.tag.Equals("Rock"))
            {
                int r = Random.Range(-1, 1);
             
                if(r ==0)
                obj.transform.position = new Vector3(oldPos, oldRockPos.y, 0);
                else
                    obj.transform.position = new Vector3(oldPos, -7, 0);
                Debug.Log(r);
            }
        
            else
            obj.transform.position = new Vector3(oldPos, Random.Range(-6, -4), 0);
        }
        
    }

   

}
