using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour 
{
    private float dampTime = 1.0f;                      //How much should the camera wait to follow the player
    private Vector3  velocity = Vector3.zero;           //
    private Transform myTransform;                      //Camera's transform component
    //public Transform target;
    private Transform target;                           //Camera's target transform

    //The target will have to be set to null when the player dies
    //That way the camera will not follow the player after he dies or falls
    public Transform TARGET                             
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }
	// Use this for initialization
	void Start () 
    {
        target = GameObject.FindGameObjectWithTag(Tags.Player).transform;                   //Initialize the camera to follow the player
        myTransform = transform;                                                            //Get the camera transform into the cache, that it doesn't have to be initialized multiple times
	}

	// Update is called once per frame
	void Update () 
    {
        cameraMove();               //Call the movement of the camera
	}


    //I don't remember what I did here
    //Fortunately it works
    //I will redo my research so that I can explain this one better
    
    void cameraMove()
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta;                  
            
            
            delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.0f, 0.5f));
            
            Vector3 destination = myTransform.position + delta;
            myTransform.position = Vector3.SmoothDamp(myTransform.position, destination, ref velocity, dampTime);
        }
    }
}
