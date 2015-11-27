using UnityEngine;
using System.Collections;
using System;

public class Attack : MonoBehaviour {
    private Animator anim;
    public ulong power;

    void Start () {
		anim = GetComponentInChildren<Animator>();
    }

	void Update () {
        if (Input.GetButtonDown("Attack")) {
            anim.SetTrigger("Attack");
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        var target = other.GetComponent<Health>();
        if (target != null) {
            target.hurt(power);
        }
    }
}
