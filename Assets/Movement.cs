using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	
	public CharacterController charCon;
	public Transform transform;
	public Animator anim;
	public Vector3 velocity = new Vector3(0, 0, 0);
	public float force = 1f;
	//public float gravity = -1f;	SimpleMove() doesn't take a y-axis input
	
    void Start()
    {

    }

    void Update()
    {
		Move_Rotate();
		Animate();
    }
	
	private void Move_Rotate()
	{
		
		charCon.SimpleMove(velocity);

		//Reset z velocity
		if ( !Input.GetKey("w") && !Input.GetKey("s") )
		{
			velocity.z = 0f;
		}

		//Resets x velocity
		if ( !Input.GetKey("a") && !Input.GetKey("d") )
		{
			velocity.x = 0f;
		}

		//Get input
		if ( Input.GetKey("w") )
			{
				velocity.z = force * Time.deltaTime;
				transform.eulerAngles = new Vector3( 0, 0, 0);
			}
		
		if ( Input.GetKey("s") )
			{
				velocity.z = -force * Time.deltaTime;
				transform.eulerAngles = new Vector3( 0, 180, 0);
			}

		if ( Input.GetKey("a") )
			{
				velocity.x = -force * Time.deltaTime;
				transform.eulerAngles = new Vector3( 0, 270, 0);
			}
		
		if ( Input.GetKey("d") )
			{
				velocity.x = force * Time.deltaTime;
				transform.eulerAngles = new Vector3( 0, 090, 0);
			}
			
	}
	
	private void Animate()
	{
		
		if ( Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d") )
		{
			anim.SetBool( "walk", true);
		}
		else if ( !Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d") )
		{
			anim.SetBool( "walk", false);
		}
		
	}
	
}

// ------ NOTES ------

// ! = NOT 			if ( !a )			if NOT (a) then (b)
//						{ 
//							b;
//						}
//
// && = AND			if ( a && b)		if (a) AND (b) then (c)
//						{
//							c;
//						}
//
// || = OR			if ( a || b)		if (a) OR (b) then (c)
//						{
//							c;	
//						}

