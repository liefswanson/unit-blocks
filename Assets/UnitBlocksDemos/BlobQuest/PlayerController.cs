using UnityEngine;
using System.Collections;
using UnitBlocks.Platformer;

namespace UnitBlocks
{
    namespace BlobQuest
    {
        [RequireComponent( typeof (Animator))]
        [RequireComponent( typeof (PlayerMovement))]
        [RequireComponent( typeof (Health))]
        // cannot RequireComponent on weapon, as it is not on the top level
        // it is on the actual subsprite which makes up the weapon
        public class PlayerController : UnitBlocks.Controller
        {
            private float x;
            private float y;

            private Animator anim;
            private Movement move;
            private Health hp;

            private Weapon weapon;

            public void Start() {
                anim = GetComponent<Animator>();
                move = GetComponent<PlayerMovement>();
                hp = GetComponent<Health>();
                weapon = GetComponentInChildren<Weapon>();
            }

            public void Update() {
                x = Input.GetAxis("Horizontal");
                // y = Input.GetAxis("Vertical");

                move.Move(x);
            }
        }
    }
}
