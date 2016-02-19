using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour 
{
	public GameObject gunEnd;

	private ShootingController shooting;

	// Use this for initialization
	void Start () 
	{
		shooting = gunEnd.GetComponent <ShootingController>();
		//startShooting ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void startShooting()
	{
		shooting.startShooting ();
	}

	public void stopShooting()
	{
		shooting.stopShooting ();
	}
}
