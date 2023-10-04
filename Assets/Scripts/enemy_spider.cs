using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spider : MonoBehaviour
{
    public Transform center;

    public float AngularSpeed;
    public float RotationRadius;

    private float posX = 0;
    private float posY = 0;
    private float angle = 0;

    Animator anim;
    bool Dead;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        Dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dead)
        {
            posX = center.position.x + Mathf.Cos(angle) * RotationRadius;
            posY = center.position.y + Mathf.Sin(angle) * RotationRadius;
            transform.position = new Vector2(posX, posY);
            angle = angle + Time.deltaTime * AngularSpeed;

            if (angle >= 360)
            {
                angle = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ------------------ Player ---------------------------
         if (collision.gameObject.CompareTag("Player"))
         {
             Debug.Log(collision.gameObject);
             anim.SetBool("isDead", true);
             Dead = true;

             Invoke("Destroy", 2f);
         }

         if (collision.gameObject.CompareTag("Bullet"))
         {
             Debug.Log(collision.gameObject);
             anim.SetBool("isDead", true);
             Dead = true;

             Invoke("Destroy", 3f);

             Destroy(collision.gameObject);
         }

    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
