using UnityEngine;
using System.Collections;

public class MovingTarget : MonoBehaviour {

	public int fallSpeed;
	// Use this for initialization
	void Start () 
	{
		fallSpeed = 5;
		GetComponent<Rigidbody2D> ().velocity = Vector2.down * fallSpeed;

	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
