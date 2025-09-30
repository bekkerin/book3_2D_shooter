﻿using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	public GameObject bullet;
	public AudioClip fireSound;
	public float moveSpeed; //ADDED
	public float bulletSpeed;

	// Use this for initialization
	void Start () 
	{
		moveSpeed = 5.0f;
		bulletSpeed = 1000f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			gameObject.transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			gameObject.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			gameObject.transform.Translate (Vector3.up * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			gameObject.transform.Translate (Vector3.down * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			GameObject b = (GameObject)(Instantiate (bullet, transform.position + transform.up * 1.5f, Quaternion.identity));
			b.GetComponent<Rigidbody2D> ().AddForce (transform.up * bulletSpeed);
			GetComponent<AudioSource> ().clip = fireSound;
			GetComponent<AudioSource> ().Play ();
		}

		//Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);
		//viewPortPosition.x = Mathf.Clamp01(viewPortPosition.x);
		//viewPortPosition.y = Mathf.Clamp01(viewPortPosition.y);
		//transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);

		Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);
		Vector3 viewPortXDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.left/2);
		Vector3 viewPortYDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.up/2);

		float deltaX = viewPortPosition.x - viewPortXDelta.x;
		float deltaY = -viewPortPosition.y + viewPortYDelta.y;

		viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, 0+deltaX, 1-deltaX);
		viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, 0+deltaY, 1-deltaY);
		transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);

	}
}
