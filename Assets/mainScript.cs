using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour {

	public GameObject player;
	public float bigCircleRadius;
	public float smallCircleRadius;
	public float revolutionSpeed;
	public float currentAngle;
    public float ang;
    private float revolutions;
	public float gravity;
	public float[] jumpForce;
	private float jumpOffset = 0;
	private int jumps = 0;
	private float currentJumpForce = 0;

    public float PoolingTime = 0f;
    public float PoolTime = 1f;

    void Start () {
        revolutions = bigCircleRadius / smallCircleRadius + 1;
	}

	void Update () {
		handleJumps ();
		handleRevolution (Time.deltaTime);

        PoolingTime += Time.deltaTime;
        if (PoolingTime > PoolTime)
        {
            PoolingTime = 0;
            gameObject.GetComponent<coinPool>().poolCoin(currentAngle);
        }
	}

	void handleJumps(){
		if (Input.GetButtonDown ("Fire1")) {
			if (jumps < 2) {
				jumps++;
				currentJumpForce = jumpForce [jumps - 1];
			}	
		}
		if (jumps > 0) {
			jumpOffset += currentJumpForce;
			currentJumpForce -= gravity;
			if (jumpOffset < 0) {
				jumpOffset = 0;
				jumps = 0;
				currentJumpForce = 0;
			}
		}
	}

	void handleRevolution(float elapsedTime){
		currentAngle += 360f * elapsedTime / revolutionSpeed;
        ang = Mathf.Abs( currentAngle % 360f);
		Vector2 newPosition = player.transform.position;
		float radians = currentAngle * Mathf.Deg2Rad;
		float totalRadius = bigCircleRadius + smallCircleRadius + jumpOffset;
		newPosition.x = totalRadius * Mathf.Cos (radians);
		newPosition.y = totalRadius * Mathf.Sin (radians);
		player.transform.position = newPosition;
		player.transform.Rotate (0, 0, 360f * revolutions * elapsedTime / revolutionSpeed);
	}

    

}