using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;

	PlayerMove playerMove;
	PlayerAttack playerAttack;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
