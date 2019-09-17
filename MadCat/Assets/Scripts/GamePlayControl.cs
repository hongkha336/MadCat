using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayControl : MonoBehaviour {

    public GameObject Background1;
    public GameObject Background2;
    public GameObject DarkBackGround;
    public float timer = 0;
	// Use this for initialization
	void Start () {
		
        if(Cat == null)
        {
            Cat = GameObject.FindGameObjectWithTag("Player");
            pnEndGame.SetActive(false);
        }
        difficult = 10;

        Background1.SetActive(true);
        Background2.SetActive(false);
        DarkBackGround.SetActive(false);
        isDay = 1;
        gameGate.SetActive(false);
        temp = Random.Range(5,11);
	}
    public int appearTime;
    public GameObject canVasText;
    public GameObject Walls;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public bool isWall = false;
    public GameObject Cat;
    bool isPlayerDead;
    public Text txtPoint;

    int gamePoint = 0;

    public GameObject pnEndGame;
    public Text endPoint;
    public Button restart;


    public int difficult;// độ khó
   public void getPoint(int i)
    {
        gamePoint += i;
        isBox = false;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    bool isCreate = false;
    // Update is called once per frame
    void endGame()
    {
        
        pnEndGame.SetActive(true);

        endPoint.text = gamePoint.ToString();
        Time.timeScale = 0;
        canVasText.SetActive(false);
        

    }

    bool isChange = false;
    bool isBox = false;
	void Update () {


        if(gamePoint %20 == 0 && gamePoint >0 && !isBox)
        {
            isBox = true;
            createBox();
        }
        ///////// BOOOOM NÈ CÁC MẸ
        bombControl();

        if((int) timer%90 == 0 && timer >120)
        {
            createLife();
            timer += 1;
        }

        if (timer>800 && !isCreate)
        {
            gameGate.SetActive(true);

            isCreate = true;
        }

        isPlayerDead = Cat.GetComponent<PlayerControl_bk>().isDead;
        if(isPlayerDead)
        {
            endGame();
        }
        
     
        if (timer >=appearTime && !isWall)
        {
            isWall = true;

            var rotation = Quaternion.LookRotation(gameObject.transform.position - gameObject.transform.position);
            rotation.x = 0;
            rotation.y = 0;
            rotation.z = 0;
            Vector2 place = transform.position;
            place.y += 1;
            place.x += 3;

            GameObject fireballclone = Instantiate(Walls,place , rotation) as GameObject;
        }


        if( timer>200 && timer<210 && !isChange)
        {
            isChange = true;
            

            changeDay();
        }

        if ((int)timer%difficult == 0 && timer >20)
        {
          
            var rotation = Quaternion.LookRotation(gameObject.transform.position - gameObject.transform.position);
            rotation.x = 0;
            rotation.y = 0;
            rotation.z = 0;
            Vector2 place = transform.position;
            place.y +=8;
            place.x += 10;
            int r = Random.Range(-1,1);
            if (r == -1)
            {
                GameObject fireballclone = Instantiate(Enemy1, place, rotation) as GameObject;
            }
            else
            {
                GameObject fireballclone = Instantiate(Enemy2, place, rotation) as GameObject;
            }
            if ((int)timer % (difficult + 2) == 0 && timer > 250 )
            {
                place.y = -1;
                place.x += 3;
                GameObject fireballclone = Instantiate(Enemy3, place, rotation) as GameObject;
            }

            if((int)timer % 3== 0)
                temp = Random.Range(5, 11);
            timer += 1f;
        }

  


        if (timer > 300)
            difficult = 4;
        else
            if (timer > 150)
            difficult = 5;

	}


    public void run(float time)
    {
        timer += time; 
    }

    void startGane()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPlayerDead = false;
        Cat.GetComponent<PlayerControl_bk>().makeAlive();
    }

    public void restartGame()
    {
        Debug.Log("Restart");
        startGane();
    }


    public GameObject gameGate;


    void createGate()
    {
      
        var rotation = Quaternion.LookRotation(gameObject.transform.position - gameObject.transform.position);
        rotation.x = 0;
        rotation.y = -2;
        rotation.z = 0;
        Vector2 place = transform.position;
        place.y += 5;
        place.x += 10;

        GameObject fireballclone = Instantiate(gameGate, place, rotation) as GameObject;
    }
    int isDay = 1;
    void changeDay()
    {
        if(isDay == 1)
        {
            isDay = 0;
            Background1.SetActive(false);
            Background2.SetActive(true);
            DarkBackGround.SetActive(true);
        }
        else
        {
            isDay = 1;
            Background1.SetActive(true);
            Background2.SetActive(false);
            DarkBackGround.SetActive(false);
        }
    }
    public GameObject bomb;
    int temp;
    float timer3 = 0;
    public void bombControl()
    {

        timer3 += Time.deltaTime;
        if ((int)timer % temp == 0 && timer > 320)
        {
    

            var rotation = Quaternion.LookRotation(gameObject.transform.position - gameObject.transform.position);
            rotation.x = 0;
            rotation.y = 0;
            rotation.z = 0;
            Vector2 place = transform.position;
            place.y += 10;
            place.x += Random.Range(-7, 5);

            if (difficult == 4)
            {
                if (timer3 >= 1.5)
                {
                    GameObject fireballclone = Instantiate(bomb, place, rotation) as GameObject;
                    timer3 = 0;
                }
            }
            else
            {
                if (timer3 >= 3)
                {
                    GameObject fireballclone = Instantiate(bomb, place, rotation) as GameObject;
                    timer3 = 0;
                }
            }
        }
    }
    public GameObject life;
    public void createLife()
    {

        var rotation = Quaternion.LookRotation(gameObject.transform.position - gameObject.transform.position);
        rotation.x = 0;
        rotation.y = 0;
        rotation.z = 0;
        Vector2 place = transform.position;
        place.y += 10;
        place.x += Random.Range(-7, 5);
        GameObject fireballclone = Instantiate(life, place, rotation) as GameObject;
    }
    public GameObject box;

    public void createBox()
    {
        var rotation = Quaternion.LookRotation(gameObject.transform.position - gameObject.transform.position);
        rotation.x = 0;
        rotation.y = 0;
        rotation.z = 0;
        Vector2 place = transform.position;
        place.y += 10;
        place.x += Random.Range(-7, 5);
        GameObject fireballclone = Instantiate(box, place, rotation) as GameObject;
    }

}


