using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public bool hasGameEnded = false;
    public Text score;
    public Text levelText;

    public Image GunUI;
    public GameObject JetUI;

    public Image DoorUI;

    public Button GunButton;
    public Button JetButton;
   
    public static int currentScore = 0;

    public static int currentLife = 4;
    public Image[] healthIcons;

    public Transform playerObject;
    public float restartDelay = 2f;

    

    // Start is called before the first frame update
    void Start()
    {
        score.text = ""+currentScore;
        levelText.text = "0" + SceneManager.GetActiveScene().buildIndex;

        for (int i = 0; i < currentLife; i++)
        {
            healthIcons[i].enabled = true;
        }

        GunButton.interactable = false;
        JetButton.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateCoin(int scoreValue)
    {
        currentScore += scoreValue;

        score.text = currentScore.ToString();
    }

    public void updateLife()
    {
        currentLife = currentLife - 1;
        if (currentLife >= 0)
        {
            healthIcons[currentLife].enabled = false;
        }
        Debug.Log("Life : " + currentLife);
    }
    //preventing multiple collision

    public void EndGame()
    {
       
            if (currentLife >= 0)
            {
                Invoke("LevelSpawnArea", restartDelay);
            
            }
            else
            {
                Debug.Log("Game Over");
                currentLife = 4;
                currentScore = 0;
                Invoke("GameOver", restartDelay);
            }
       
    }
    
    public void PlayerSpawn(float x, float y)
    {
        float spawnX = x;
        float spawnY = y;

        playerObject.transform.position = new Vector3(spawnX, spawnY, transform.position.z);

        FindObjectOfType<movement>().isDead = false;
        FindObjectOfType<movement>().enabled = true;
        FindObjectOfType<PlayerCollision>().jumpButton.interactable = true;

        FindObjectOfType<stateChanger>().StopJet();
        
    }

    public void LevelSpawnArea()
    {
        FindObjectOfType<movement>().playeranim.Play("anim_idle");

        int z = SceneManager.GetActiveScene().buildIndex;
        int level = z;
        Debug.Log("Level : " + level);


        if(level == 2)
        {
            PlayerSpawn(-7.431543f, -3.431697f);         
        }
        if(level == 3)
        {
            PlayerSpawn(-7.33f, -2.503f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GameOver()
    {
        SceneManager.LoadScene(0);
    }


}
