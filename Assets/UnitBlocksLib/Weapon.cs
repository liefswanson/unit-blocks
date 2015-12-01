using UnityEngine;
using System.Collections;

namespace UnitBlocks
{
    [RequireComponent(typeof(Collider2D))]
    public class Weapon : MonoBehaviour
    {
        // IMPORTANT:
        // unfortunately, if you want to add additional hit types,
        // this variable must be modified.
        // it cannot be made virtual

        public enum HitState : byte
        {
            Hit = 0,
            HitArmour, HitEnvironmentHard, HitEnvironmentSoft,
            Miss, Blocked, Parried, Dodged
        };

        public ulong power;

        public virtual bool active { protected set; get; }

        protected bool hitSomething;

        public virtual void Hit(Collider2D other)
        {
            var target = other.GetComponent<Health>();
            if (target != null)
            {
                target.Hurt(power);
            }
            HitAnim(HitState.Hit);
            HitSound(HitState.Hit);

            hitSomething = true;
        }
        protected virtual void HitAnim(HitState swing) { }
        protected virtual void HitSound(HitState swing) { }

        public virtual IEnumerator Attack()
        {
            AttackAnim();
            AttackSound();
            active = true;
            hitSomething = false;

            yield return new WaitForSeconds(0);
            if (!hitSomething)
            {
                HitAnim(HitState.Miss);
                HitSound(HitState.Miss);
            }
            active = false;
        }

        protected virtual void AttackAnim() { }
        protected virtual void AttackSound() { }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (active)
            {
                Hit(other);
            }
        }
    }
}
