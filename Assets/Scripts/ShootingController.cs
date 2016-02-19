using UnityEngine;
using System.Collections;

public class ShootingController : MonoBehaviour 
{
	public ParticleSystem gunParticles;                   
	public Light shotLight;
	public double timeBShots;
	public int range;
	public double effectDuration;			//must be less than timeBShots

	private double accTime;		//used to enforce fire rate
	private double accTime2;	//for effect duration
	private bool shooting;
	private bool shotEffects;	//true when shot effects are turned on
	private int playerMask;
	private Ray shootRay;
	private ParticleSystem.EmissionModule shotParticles;

	// Use this for initialization
	void Start () 
	{
		accTime = 0;
		accTime2 = effectDuration;
		shooting = true;
		shotEffects = false;
		shotParticles = gunParticles.emission;
		shotParticles.enabled = false;
		playerMask = LayerMask.GetMask ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (shotEffects) 											//turn off shot effects if they were turned on
		{
			accTime2 -= Time.deltaTime;

			if (accTime2 <= 0) 
			{										
				shotLight.enabled = false;
				shotParticles.enabled = false;
				shotEffects = false;
				accTime2 = effectDuration;
			}
		}
		if (shooting)
		{
			accTime -= Time.deltaTime;

			if (accTime <= 0)										//time to shoot a "bullet"	
			{
				shotEffects = true;
				shotLight.enabled = true;											//TRIGGER GUNSHOT SOUND FROM HERE
				shotParticles.enabled = false;
				//gunParticles.Simulate (0);
				shotParticles.enabled = true;

				shootRay.origin = transform.position;
				shootRay.direction = transform.forward;

				RaycastHit[] hits;
				hits = Physics.RaycastAll (shootRay, range, playerMask);
				for (int i = 0; i < hits.Length; i++) 
				{
					HitController playerHit = hits[i].collider.GetComponent <HitController>();
					playerHit.getHit (hits[i].point);
				}
				accTime = timeBShots;				
			}
		}		
	}

	public void startShooting()
	{
		shooting = true;
		accTime = 0;
	}

	public void stopShooting()
	{
		shooting = false;
		accTime = 0;
	}
}
