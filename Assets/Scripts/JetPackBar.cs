using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetPackBar : MonoBehaviour
{
    public float speed = 10f;
    public Slider jet;
    public int maxJet = 100;
    public int current = 0;

    public Joystick joystick;

    public Animator playeranim;

    stateChanger sc;

    float move;
    float moveX;

    void Awake()
    {
        current = maxJet;
    }

    void Start()
    {
       // playeranim = GetComponent<Animator>();
        sc = GetComponent<stateChanger>();
    }

    void FixedUpdate()
    {
         move = Input.GetAxis("Vertical");
         moveX = Input.GetAxis("Horizontal");

        //move = joystick.Vertical;
        //moveX = joystick.Horizontal;

        transform.position += new Vector3(0f, move * speed, 0f) * Time.deltaTime;
        transform.position += new Vector3(moveX * speed, 0f, 0f) * Time.deltaTime;

    }

    public void ProgressBar()
    {
        if(jet.value > 0)
        {
            current-=3;
            jet.value = current;
        }
        else if(jet.value <= 0)
        {
            sc.StopJet();
        }
    }
}
