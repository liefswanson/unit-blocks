using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Movement : MonoBehaviour {
	private Rigidbody2D rb;
 	private bool facingRight = true;
 	public float maxSpeed;

	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}

	public void Forward(float horizontalInput) {
		// If horizontalInput goes to the right
		// while facing left, flip and set direction.

		// checks currently looking forward
		if(horizontalInput > 0 && !facingRight ||
		   horizontalInput < 0 && facingRight) {
            Flip();
        }
        // Find direction entity is facing.
        var direction = facingRight ? Vector2.right : -Vector2.right;

		rb.velocity = direction * maxSpeed * Mathf.Abs(horizontalInput);
		// add a force to the currently faced direction

		// cap the velocity at a maximum,
		// so that there is a limit to the maximum momentum of the character
 	}

	public void Flip() {
		// responsible for making the character change directions
		facingRight = !facingRight;

        // Multiply the entity's x local scale by -1.
        var scale = transform.localScale;
        scale.x *= -1;
		transform.localScale = scale;

    }
}
