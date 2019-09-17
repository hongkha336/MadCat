using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {

    public float shootdelay = 0, damage = 20;
    public LayerMask whattohit;
    public Transform firepont;
    public  float gunSpeed = 2;
    public GameObject Cat;
    public GameObject newObj;

    public GameObject fireBall;
    public float timerWeaponOut;

    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject weapon5;
  public float timeFade;
    int thisWeapon;

    bool isBack = false;
	// Use this for initialization
	void Start () {
        if(newObj == null)
        newObj = GameObject.FindGameObjectWithTag("ShootPoint");

        firepont = newObj.transform;

        if (Cat == null)
        {
            Cat = GameObject.FindGameObjectWithTag("Player");
        }


        thisWeapon = 1;        
        fireBall = weapon1;
        timeFade = fireBall.GetComponent<FireBall>().timeFade;
        timerWeaponOut = fireBall.GetComponent<FireBall>().timerWeaponOut;
        gunSpeed = fireBall.GetComponent<FireBall>().moveSpeed;
    }


    public void changeWeapon(int  weapon)
    {
        if (weapon == 1)
            fireBall = weapon1;
        else
        {
            if (weapon == 2)
            {
                fireBall = weapon2;
            }
            else
            {
                if (weapon == 3)
                {
                    fireBall = weapon3;
                }
                else
                {
                    if (weapon == 4)
                    {
                        fireBall = weapon4;
                    }
                    else
                        fireBall = weapon5;
                }
            }


        }
       
    }

    // Update is called once per frame
    void Update () {



        if(thisWeapon != 1)
        {
            timerWeaponOut -= Time.deltaTime;
            if(timerWeaponOut <= 0)
            {
                setWeapon(1);
            }
        }


          isBack = Cat.GetComponent<PlayerControl_bk>().isBack;

      //  shot();
        shootdelay += Time.deltaTime;
        if(shootdelay >=0.5f)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                shootdelay = 0;
                shot();
            }
        }
	}

    

    public void shot()
    {


        Vector2 firepointpos = new Vector2(firepont.position.x, firepont.position.y);
        Vector2 nextPoint = new Vector2(firepont.position.x+1, firepont.position.y);

        RaycastHit2D hit;
        if (isBack)
        {
            hit = Physics2D.Raycast
                (
                firepointpos, (nextPoint - firepointpos)
                , 10f, whattohit
                );
            Debug.DrawLine(firepointpos, (nextPoint - firepointpos) * 100, Color.cyan);

            var rotation = Quaternion.LookRotation(nextPoint - firepointpos);
            rotation.x = 0;
            rotation.y = 0;
            GameObject fireballclone = Instantiate(fireBall, transform.position, rotation) as GameObject;
            fireballclone.GetComponent<Rigidbody2D>().velocity = (nextPoint - firepointpos) * gunSpeed;
            //NÈ
        
            Destroy(fireballclone, timeFade);
        }
        else
        {
            hit = Physics2D.Raycast
                           (
                           firepointpos, ( firepointpos - nextPoint)
                           , 10f, whattohit
                           );
            Debug.DrawLine(firepointpos, (firepointpos- nextPoint) * 100, Color.cyan);


            var rotation = Quaternion.LookRotation(firepointpos - nextPoint);
            rotation.x = 0;
            rotation.y = 0;
            GameObject fireballclone = Instantiate(fireBall, transform.position, rotation) as GameObject;
            fireballclone.GetComponent<Rigidbody2D>().velocity = (firepointpos - nextPoint) * gunSpeed;
            fireballclone.transform.localScale = new Vector3(-1 * fireballclone.transform.localScale.x, fireballclone.transform.localScale.y, 0);

            Destroy(fireballclone, timeFade );
        }


       

        if (hit.collider!= null)
        {
            Debug.DrawLine(firepointpos, hit.point, Color.red);
            // kiểm tra va chạm cái gì
            Debug.Log("We hit " + hit.collider.name);
        }


    }

    public void setWeapon( int no )
    {
        thisWeapon = no;
        changeWeapon(thisWeapon);
        timeFade = fireBall.GetComponent<FireBall>().timeFade;
        timerWeaponOut = fireBall.GetComponent<FireBall>().timerWeaponOut;
        gunSpeed = fireBall.GetComponent<FireBall>().moveSpeed;
    }
}
