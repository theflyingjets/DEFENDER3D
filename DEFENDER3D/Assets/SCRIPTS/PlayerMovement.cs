using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    private float Speed;
    private Transform MyTransform;
    private Rigidbody MyRigidBody;
	// Use this for initialization
	void Start () 
    {
        Speed = 3.0f;
        MyTransform = transform;
        MyRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        MyRigidBody.velocity = new Vector3(Horizontal * Speed, 0.0f, Speed);//Vector3.right * Horizontal * Speed;
        //MyRigidBody.AddForce(Vector3.right * Horizontal);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.Goal)
        {
            print("GOAL IS FUNCTIONAL");
        }
    }
}
