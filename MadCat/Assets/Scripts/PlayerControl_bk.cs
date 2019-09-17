using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl_bk : MonoBehaviour {

    public int myLife;
    public Text txtMyLife;
    public void getLife(int i)
    {
        myLife += i;
        txtMyLife.text = "Life: " + myLife.ToString();
    }

    public void killLife(int i)
    {
        myLife -= i;
        txtMyLife.text = "Life: " + myLife.ToString();
    }

    private GameObject obj;
    public float FlayPower;
    bool isFly;
    public int moveSpeed;

    private GameObject controller;
    public bool isDead = false;

    Animator anim;

    public bool isInCenterScreen = false;


   public float timerFly;

    // Use this for initialization
    void Start()
    {
        timerFly = 0;
        obj = gameObject;
        isFly = false;
        moveSpeed = 3;
        isInCenterScreen = false;
          isDead = false;
    anim = obj.GetComponent<Animator>();


        anim.SetBool("isRunnning", false);
        anim.SetBool("IsFight", false);

        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("controller");
        }
        
        txtMyLife.text = "Life: " + myLife.ToString();
    }

   public bool isBack = true;

    // Update is called once per frame
    void Update()
    {
        //Bay
        timerFly += Time.deltaTime;

        if (myLife <= 0)
            isDead =true;

        if (obj.transform.position.x >= 0)
        {
            Debug.Log("***************True*******************");
            isInCenterScreen = true;
        }
        else
        {
            Debug.Log("***************F*******************");
            isInCenterScreen = false;
        }

 

        if (Input.GetKey(KeyCode.UpArrow) && !isFly )
        {
            if (timerFly > 0.5f)
            {

                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FlayPower));
                isFly = true;
                Debug.Log("Run after dead");
                timerFly = 0;
            }

        }
        else
        {
            Debug.Log("Run after dead");
            // chạy qua phải
            if (Input.GetKey(KeyCode.RightArrow) && !isInCenterScreen)
            {

                if (!isBack)
                {
                    obj.transform.localScale = new Vector3(-1 * obj.transform.localScale.x, obj.transform.localScale.y, 0);
                    isBack = true;
                }

                obj.transform.Translate(new Vector3(1 * Time.deltaTime * (moveSpeed), 0, 0));
                controller.GetComponent<GamePlayControl>().run(0.1f);
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
    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("Untagged") && !other.gameObject.tag.Equals("Center") || other.gameObject.tag.Equals("Ground"))
        {
            isFly = false;



        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("Untagged") && !other.gameObject.tag.Equals("Center") || other.gameObject.tag.Equals("Ground"))
        {
            isFly = false;



        }
        if (other.gameObject.tag.Equals("Center"))
            isInCenterScreen = true;

        if (other.gameObject.tag.Equals("Gate"))
        {
            SceneManager.LoadScene(1);
            Debug.Log("TriggerGate");

        }

        if (other.gameObject.tag.Equals("Dead"))
        {
            isDead = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Center"))
            isInCenterScreen = false;
      
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            string name = other.collider.name.ToString() + "(Clone)";
            if (other.collider.name.ToString().Equals("Monter 1(Clone)"))
                killLife(10);
            if(other.collider.name.ToString().Equals("Dead 1(Clone)"))
                killLife(20);
            if (other.collider.name.ToString().Equals("ghost(Clone)"))
                killLife(10);

            Debug.Log( other.gameObject.name.ToString());
            obj.transform.position = new Vector3(obj.transform.position.x - 1f, obj.transform.position.y, 0);
        }
    }


    public void makeAlive()
    {
        isDead = true;
    }
}
