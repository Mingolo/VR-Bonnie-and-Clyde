using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour 
{	
	/*
	 * 
	 *
	 * 			***************** THIS SCRIPT IS JUST FOR TESTING PURPOSES, SHOULD PROBABLY DELETE IT AND PUT YOUR OWN	*********************
	 * 
	 * 
	 * 
	 */

	private Rigidbody rigid;

	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent <Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void FixedUpdate()
	{
		rigid.AddRelativeForce (0, 0, 1);
	}
}
