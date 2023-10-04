using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public int scoreValue = 100;

    public GameObject player;

    GameManager gameManager;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.name != "Door")
        {
            Debug.Log("You have picked the " + gameObject.name);
            Destroy(gameObject);
            gameManager.updateCoin(scoreValue);
        }

    }

}
