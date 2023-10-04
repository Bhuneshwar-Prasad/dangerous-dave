using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipBullet : MonoBehaviour
{
    public GameObject bullet;
    GameObject bulletclone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FireBullet()
    {
        bulletclone = Instantiate(bullet, transform.position, transform.rotation);
        bulletclone.transform.localScale = transform.localScale;
    }

}
