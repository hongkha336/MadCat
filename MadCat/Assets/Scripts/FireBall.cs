using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {



    public float moveSpeed;
    public float timeFade;
    public int hurt;
    public float timerWeaponOut;
    public float shootTime;
	// Use this for initialization
	void Start () {

        if (Cat == null)
            Cat = GameObject.FindGameObjectWithTag("Player");
        isBack = false;
	}

    bool isBack;

    public GameObject Cat;
	// Update is called once per frame
	void Update () {
        //   Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity);
       
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("Untagged") && !other.gameObject.tag.Equals("FireBalls") && !other.gameObject.tag.Equals("Player"))
        {
            if (other.gameObject.tag.Equals("Enemy"))
            {
                other.gameObject.GetComponent<WalkingDead>().Hurt(hurt);
            }
         //   Debug.Log("Hit " + other.collider.name.ToString());
            Destroy(gameObject);

        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.tag.Equals("Untagged") && !other.gameObject.tag.Equals("FireBalls") && !other.gameObject.tag.Equals("Player"))
        {
            if(other.gameObject.tag.Equals("Enemy"))
            {
                other.gameObject.GetComponent<WalkingDead>().Hurt(40);
            }
            Debug.Log("Hit " + other.collider.name);
            Destroy(gameObject);
            
        }
     
    }
}
