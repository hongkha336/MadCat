using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        int r = Random.Range(2, 5);
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponentInChildren<Pistol>().setWeapon(r);
            Destroy(gameObject);
        }
        if (other.gameObject.tag.Equals("Ground") || other.gameObject.tag.Equals("Untagged") || other.gameObject.tag.Equals("Walls") || other.gameObject.tag.Equals("W"))
        {
            gameObject.GetComponent<DownControl>().setMoveSpeed(0);
            Destroy(gameObject, 5);

        }
        Debug.Log("Tym dung collision");
    }



    void OnTriggerEnter2D(Collider2D other)
    {

        int r = Random.Range(2, 5);
        Debug.Log(r);
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponentInChildren<Pistol>().setWeapon(r);
            Destroy(gameObject);
        }
        if (other.gameObject.tag.Equals("Ground") || other.gameObject.tag.Equals("Untagged") || other.gameObject.tag.Equals("Walls") || other.gameObject.tag.Equals("W"))
        {
            gameObject.GetComponent<DownControl>().setMoveSpeed(0);
            Destroy(gameObject, 5);

        }
        Debug.Log("Tym dung collision");
    }
}
