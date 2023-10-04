using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float speed = 10f;
    public float jump_speed = 350f;
    public Animator playeranim;

    public Joystick joystick;
    public bool isDead = false;

    Rigidbody2D rb;

    public movement move;

    public float Hmove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playeranim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        move = GetComponent<movement>();

        isDead = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Hmove = Input.GetAxis("Horizontal") * speed;
        //Hmove = joystick.Horizontal * speed;

        playeranim.SetFloat("Speed", Mathf.Abs(Hmove));



    }

    public void jump()
    {
            if (rb.velocity.y == 0)
            {
                rb.AddForce(Vector2.up * jump_speed, ForceMode2D.Force);
            }
    }

    void FixedUpdate()
    {
        //var move = joystick.Horizontal;

        transform.position += new Vector3(Hmove * Time.deltaTime, 0f, 0f);
 
            if(rb.velocity.y == 0)
            {
                playeranim.SetBool("isJumping", false);
            }

            if(rb.velocity.y > 0)
            {
                playeranim.SetBool("isJumping", true);
            }

            if(rb.velocity.y < 0)
            {
                playeranim.SetBool("isJumping", false);
            }
    }
}
