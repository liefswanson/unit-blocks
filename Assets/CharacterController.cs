using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Movement))]
public class CharacterController : MonoBehaviour {
	public float horizontalInput;
	public float verticalInput;

	private Movement movement;

  	// Use this for initialization
  	void Start () {
		movement = gameObject.GetComponent<Movement>();
	}

	// Update is called once per frame
	void Update () {
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput   = Input.GetAxisRaw("Vertical");

		if (horizontalInput != 0){
		  movement.Forward(horizontalInput);
		}
	}
}
