using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public int DamageOnHit = 20;
	public float Range = 0.8f;
	public float Height = 0.2f;
	public float TimeBetweenHits = 0.5f;

	Animator anim;
	float timer;
	Vector3 defaultTipPos;

	// Use this for initialization
	void Start () {
		defaultTipPos = new Vector3(transform.localPosition.x, transform.localPosition.y);
		anim = (Animator) GetComponentInParent<Animator>();
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		// attacking
		if (anim.GetBool ("Attack") && timer > TimeBetweenHits) {
			transform.localPosition = new Vector3 (defaultTipPos.x + Range, 
			                                          defaultTipPos.y + Height, 0);
			timer = 0;
		}

		// reset sword after attack
		if (timer >= TimeBetweenHits && transform.localPosition.magnitude > defaultTipPos.magnitude){
			transform.localPosition = defaultTipPos;
		}
	}
}
