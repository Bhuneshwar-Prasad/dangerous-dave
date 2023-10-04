using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stateChanger : MonoBehaviour
{
    public Slider jetprogress;
    PlayerCollision pc;
    JetPackBar sc_jet;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerCollision>();
        sc_jet = GetComponent<JetPackBar>();
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    public  bool startJet = false;
    public void JumpJetMovement()
    {
        startJet = !startJet;

        if (startJet && sc_jet.jet.value > 0)
        {
            StartJet();           
        }
        else
        {
            StopJet();
            Debug.Log("Out of Fuel");
        }

    }

    public void StopJet()
    {
        pc.jumpButton.interactable = true;
        gameObject.GetComponent<JetPackBar>().enabled = false;
        gameObject.GetComponent<movement>().enabled = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        sc_jet.playeranim.SetBool("jet_active", false);
        sc_jet.CancelInvoke();
    }

    public void StartJet()
    {
        sc_jet.InvokeRepeating("ProgressBar", 1f, 1f);   
        pc.jumpButton.interactable = false;
        gameObject.GetComponent<JetPackBar>().enabled = true;
        gameObject.GetComponent<movement>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        sc_jet.playeranim.SetBool("jet_active", true);
    }
}
