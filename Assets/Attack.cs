using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
    private Animator anim;

    // Use this for initialization
    void Start () {
				anim = GetComponentInChildren<Animator>();
    }

	// Update is called once per frame
	void Update () {
        bool Attack = Input.GetButtonDown("Attack");
        anim.SetBool("Attack", Attack);
    }
}
