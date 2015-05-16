using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour 
{
    private float bulletPerSec;
    private bool shooting;
    private List<GameObject> myProjectileList;
    private GameObject myProjectile;
    private int totalProjectilesCreated;
    private Transform myTransform;
    

	// Use this for initialization
	void Start () 
    {
        
        myTransform = transform;
        /*
        if(this.gameObject.tag == Tags.Gun)
        {
            bulletPerSec = 7.0f;
        }
        
        else */
        /*
        if(this.gameObject.tag == Tags.EnemyGun)
        {
            bulletPerSec = 0.5f;
        }
        */
        shooting = false;
        totalProjectilesCreated = 5;
        myProjectileList = new List<GameObject>();
        createProjectiles();
        InvokeRepeating("Shoot", 0.0f, 1.0f / bulletPerSec);
	}
	
	// Update is called once per frame
	void Update () 
    {
        myInput();
	}

    void Shoot()
    {
        if(!shooting)
        {
            return;
        }
        activateProjectile();
    }

    void myInput()
    {
        
        if (Input.GetButton("Fire1")) //&& this.gameObject.tag == Tags.Gun)
        {
            shooting = true;
        }
        
        else 
        {
            shooting = false;
        }
        
        //if(this.gameObject.tag == Tags.EnemyGun)
        //{
        //RaycastHit2D hit = Physics2D.Raycast(myTransform.position, myTransform.forward, 500.0f, LayerMask.GetMask("Player"));
        //Debug.DrawRay(myTransform.position, myTransform.forward, Color.black);
        //if(hit.collider != null && hit.collider.tag == Tags.Player)
        //{
        //    shooting = true;
        //}
        //}
    }

    private void createProjectiles()
    {

        for (int i = 0; i < totalProjectilesCreated; i++)
        {
            myProjectile = Instantiate(Resources.Load("Projectile")) as GameObject;
            myProjectileList.Add(myProjectile);
            myProjectileList[i].SetActive(false);
        }
    }

    public void activateProjectile()
    {
        for (int i = 0; i < totalProjectilesCreated; i++)
        {
            if (myProjectileList[i].activeSelf == false)
            {
                myProjectileList[i].SetActive(true);
                myProjectileList[i].GetComponent<Projectile>().Activate();
                myProjectileList[i].transform.position = this.myTransform.position;
                myProjectileList[i].transform.rotation = this.transform.rotation;
                return;
            }
        }
    }
}
