using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour 
{
	public GameObject gunEnd;

	private ShootingController shooting;
	private bool bol;

	// Use this for initialization
	void Start () 
	{
		shooting = gunEnd.GetComponent <ShootingController>();
		bol = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bol) 
		{
			startShooting ();
			bol = false;
		}
		if (Time.time > 20) 
		{
			shooting.stopShooting ();
		}
	
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
