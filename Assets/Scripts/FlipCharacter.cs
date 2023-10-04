using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    movement move_sc;

    bool facingRight = false;
    float Hmove;

    // Start is called before the first frame update
    void Start()
    {
        move_sc = GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
         Hmove = Input.GetAxis("Horizontal");
       // Hmove = move_sc.joystick.Horizontal;

        if (Hmove > 0 && facingRight)
        {
            flip();
        }
        else if (Hmove < 0 && !facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        if (move_sc.isDead == false)
        {
            facingRight = !facingRight;

            transform.Rotate(0, 180, 0);
        }
    }
}
