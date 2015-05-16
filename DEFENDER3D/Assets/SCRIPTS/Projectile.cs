using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    private float life = 5.0f;
    private float speed;
    private float timeToDie = 0.0f;
    private Transform myTransform;
    public GameObject gunTransform;
    public AudioClip hitSound;
    //public AudioClip shootSound;

    void Start()
    {
        //playerTranform = GameObject.FindGameObjectWithTag(Tags.player).transform;
        myTransform = transform;
    }

    void Update()
    {
        countDown();
        movement();
    }


    public void Activate()
    {
        //AudioSource.PlayClipAtPoint(shootSound, Vector2.zero);  
        timeToDie = Time.time + life;
        //transform.position = GameObject.FindGameObjectWithTag(Tags.Gun).transform.position;
        speed = 20.0f;
    }

    public void Deactivate()
    {

        this.gameObject.SetActive(false);
    }

    private void countDown()
    {
        if (timeToDie < Time.time)
        {
            Deactivate();
            //anim.SetTrigger("Deactivate");
        }
    }

    public void movement()
    {
        Vector2 velocity = speed * Time.deltaTime * gunTransform.transform.up;//myTransform.up;
        myTransform.Translate(velocity);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        /*
        if (col.gameObject.tag == Tags.Enemy)
        {
            AudioSource.PlayClipAtPoint(hitSound, Vector2.zero);
            col.gameObject.GetComponent<EnemyMovement>().HEALTH--;
            Deactivate();
        }
        */
        if(col.gameObject.tag == Tags.Player)
        {
            AudioSource.PlayClipAtPoint(hitSound, Vector2.zero);
            //anim.SetTrigger("Deactivate");
        }
    }
}
