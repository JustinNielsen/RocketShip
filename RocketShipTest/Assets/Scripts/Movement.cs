using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public float thrust = 5f;
    public float rotationSpeed = 5f;
    public SpriteRenderer flameRenderer;
    public Rigidbody2D rb;
    public Camera cam;
    public Camera miniMap;
    public Text speedText;
    public Text highestSpeedText;

    private float highestSpeed = 0f;

	// Use this for initialization
	void Start ()
    {
        flameRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.MoveRotation(rb.rotation + (rotationSpeed * -Input.GetAxis("Horizontal")));

        if (Input.GetKey("space"))
        {
            flameRenderer.enabled = true;
            rb.AddRelativeForce(Vector2.up * thrust, ForceMode2D.Impulse);
        }
        else
        {
            flameRenderer.enabled = false;
        }

        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        miniMap.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, miniMap.transform.position.z);

        //Get speed of rocket
        Vector2 vel = rb.velocity;
        float rocketSpeed = vel.magnitude;
        speedText.text = "Speed: " + rocketSpeed.ToString("n2");

        //Get the highest speed in current session
        if(highestSpeed < rocketSpeed)
        {
            highestSpeed = rocketSpeed;
            highestSpeedText.text = "Highest Speed: \n" + highestSpeed.ToString("n2");
        }
    }
}
