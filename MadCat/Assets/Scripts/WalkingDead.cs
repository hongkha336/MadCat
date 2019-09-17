using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkingDead : MonoBehaviour {


    public int Life;
    // Use this for initialization
    public GameObject controller;
    public int point;
    public Animator anim;
	void Start () {
        if (controller == null)
            controller = GameObject.FindGameObjectWithTag("controller");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isDead", false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Life <= 0)
        {
            anim.SetBool("isDead", true);
            controller.gameObject.GetComponent<GamePlayControl>().getPoint(point);
            Destroy(gameObject);
            
        }
	}

    public void Hurt(int dm)
    {
        Life -= dm;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Dung Trigger");

      if(other.gameObject.tag.Equals("RightTrigger") || other.gameObject.tag.Equals("Reset"))
        {
            Destroy(gameObject);
        }
    }

    

}
