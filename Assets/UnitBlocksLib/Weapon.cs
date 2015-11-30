using UnityEngine;
using System.Collections;

namespace UnitBlocks
{
    public class Weapon : MonoBehaviour
    {
        public ulong power;

        protected bool _engaged;
        public virtual bool engaged { set; get; }

        public virtual void Hit(Collider2D other)
        {
            var target = other.GetComponent<Health>();
            if (target != null)
            {
                target.Hurt(power);
            }
        }
    }
}
