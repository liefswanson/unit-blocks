using UnityEngine;
using System.Collections;

namespace UnitBlocks
{
    namespace Platformer
    {
        [RequireComponent(typeof(Rigidbody2D))]
        public class Movement : MonoBehaviour
        {
            protected Rigidbody2D rb;
            public bool facingRight;

            // TODO
            // this may have to be turned into two floats,
            // I have not had a chance to test in editor
            public Vector2 maxVelocity;
            public Vector2 movementForce;

            public virtual bool crouching { set; get; }

            public virtual bool jumping { set; get; }

            public virtual void Start()
            {
                rb = GetComponent<Rigidbody2D>();
            }

            // FIXME
            // this causes so many bugs...
            // A better solution might be to have two characters, one facing right and the other facing left, and toggle them
            // however, this still might not fix the problem.
            // the problem here is rotation can cause the character to enter a collider without causing the trigger to go off.
            // the best solution would be to somehow force the turn of the character to happen during
            public virtual void Turn()
            {
                TurnAnim();
                TurnSound();
                facingRight = !facingRight;

                var scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
            protected virtual void TurnAnim() { }
            protected virtual void TurnSound() { }

            public virtual void Crouch()
            {
                CrouchAnim();
                CrouchSound();
            }
            protected virtual void CrouchAnim() { }
            protected virtual void CrouchSound() { }

            public virtual void Jump(float scale)
            {
                JumpAnim();
                JumpSound();
            }
            protected virtual void JumpAnim() { }
            protected virtual void JumpSound() { }

            public virtual void Move(float scale)
            {
                MoveAnim();
                MoveSound();
                // acceleration is backwards, or not at max
                // TODO add these if statement procedures as library functions
                if (rb.velocity.x * scale < 0
                || rb.velocity.x < maxVelocity.x) {
                    var accelForce = scale * movementForce.x * Vector2.right;
                    rb.AddForce(accelForce);
                }
            }

            public virtual void MoveAnim() { }
            public virtual void MoveSound() { }
        }
    }
}
