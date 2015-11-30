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

            public virtual bool crouching { set; get; }

            public virtual bool jumping { set; get; }

            public float movementForce;
            public float jumpForce;

            public virtual void Start()
            {
                rb = GetComponent<Rigidbody2D>();
            }

            // FIXME
            // this causes so many bugs...
            // A better solution might be to have two characters, one facing right and the other facing left, and toggle them
            // the problem here is rotation can cause the character to enter a collider without causing the trigger to go off.
            // this is a huge problem...
            // it also causes the colliders of the flipped sprite to flip incorrectly, according to some users
            // I am not sure if that is correct, but it would not surprise me
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
                // is acceleration in the direction already moving?
                // yes
                //  is rb already moving max velocity
                //  yes
                //   do nothing
                //  no
                //   create force vector as normal
                // no
                //  create force vector as normal
                // add created force vector
                // do not change velocity, ever that is a bad idea
            }
            public virtual void MoveAnim() { }
            public virtual void MoveSound() { }
        }
    }
}
