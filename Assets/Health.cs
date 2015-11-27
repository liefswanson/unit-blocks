using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public ulong max;
	private ulong current;

	void Start () {
		current = max;
	}

	void Update () {}

	public virtual void heal(ulong scale) {
		if (scale + current > max ) {
			current = max;
		} else {
			current += scale;
		}
	}

	public virtual void hurt(ulong scale) {
		if (current < scale) {
			Destroy(gameObject);
		} else {
			current -= scale;
		}
	}
}
