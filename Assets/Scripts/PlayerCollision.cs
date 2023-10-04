using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    Animator playeranim;
    GameManager gm;
    public Button jumpButton;
    JetPackBar sc_jet;


    public bool hasKey = false;
    public bool hasGun = false;
    public bool hasJet = false;

    movement moveScript;
   
    private void Start()
    {
        playeranim = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
        moveScript = GetComponent<movement>();
        sc_jet = GetComponent<JetPackBar>();
    }
    void Update()
    {
        if (moveScript.isDead)
        {
            gm.GunButton.interactable = false;
            gm.JetButton.interactable = false;
        }
        else
        {
            if (hasGun)
            {
                gm.GunButton.interactable = true;
            }
            else
            {
                gm.GunButton.interactable = false;
            }
            if (hasJet)
            {
                gm.JetButton.interactable = true;
            }
            else
            {
                gm.JetButton.interactable = false;
            }
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // ------------------ FIRE ---------------------------
        if (collision.gameObject.CompareTag("Fire"))
        {
            Debug.Log(collision.gameObject);
           
            if (moveScript.isDead == false)
            {
                jumpButton.interactable = false;
                playerDead();
                
            }
        }

        // --------------- Enemy ---------------------------

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You're Dead");

            if(moveScript.isDead == false)
            {
                jumpButton.interactable = false;
                playerDead();
            }
        }

    }

    void playerDead()
    {
        FindObjectOfType<movement>().isDead = true;
        FindObjectOfType<movement>().enabled = false;
        FindObjectOfType<JetPackBar>().enabled = false;

        playeranim.SetBool("jet_active", false);
        playeranim.SetBool("isJumping", false);
        playeranim.SetBool("isDead", true);

        playeranim.Play("anim_dead");
        


        gm.updateLife();

        gm.EndGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ------------------- JET PACK --------------------------------
        if (collision.CompareTag("Jet"))
        {
            hasJet = true;

            if (hasJet)
            {
                gm.JetUI.SetActive(true);
                gm.JetButton.interactable = true;
                sc_jet.current = 100;
                sc_jet.jet.value = 100;

                Debug.Log(collision.gameObject.name + " has been picked up");
            }
            
        }

        // -------------------- CUP KEY -------------------------------
        if (collision.gameObject.name == "Cup_Key")
        {
            hasKey = true;
            if (hasKey)
            {
                gm.DoorUI.enabled = true;
            }
            else
            {
                gm.DoorUI.enabled = false;
            }
            Debug.Log("You have picked up the door Key!!!");
        }

        // ----------------- GUN -------------------------------------

        if(collision.gameObject.name == "Gun")
        {
            hasGun = true;

            if (hasGun)
            {
                gm.GunUI.enabled = true;
                gm.GunButton.interactable = true;
                
                Debug.Log("You have picked up the Gun!!");
            }
        }

        // ------------------- DOOR ------------------------------

        if (collision.gameObject.name == "Door")
        {
            if (hasKey == true)
            {
                FindObjectOfType<SceneLoader>().load();
                
                Debug.Log("I can get through the door");
            }
            else
            {
                
                Debug.Log("Get the door key first");
            }
        }

        // -------------------- WATER -------------------------

        if (collision.gameObject.CompareTag("Water"))
        {
            Debug.Log(collision.gameObject);

            FindObjectOfType<movement>().isDead = true;
            FindObjectOfType<movement>().enabled = false;
            gm.EndGame();

        }

        
    }
}
