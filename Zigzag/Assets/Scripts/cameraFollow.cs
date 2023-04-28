using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public GameObject Ball;
	Vector3 offset;
	public float lerpRate;
	public bool gameOver;

    // Use this for intialization
    void Start() {
		offset = Ball.transform.position - transform.position;
		gameOver = false; 
    }

    // Update is called once per frame
	void Update() {
		if (!gameOver) {
			Follow ();
		}
    }

	void Follow(){
		Vector3 pos = transform.position;
		Vector3 targetPos = Ball.transform.position - offset;
		pos = Vector3.Lerp (pos, targetPos, lerpRate * Time.deltaTime);
		transform.position = pos;
	}
}