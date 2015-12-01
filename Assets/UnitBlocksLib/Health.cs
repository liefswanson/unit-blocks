using UnityEngine;
using System.Collections;

namespace UnitBlocks
{
    public class Health : MonoBehaviour
    {
        public ulong max;
        public virtual ulong current { protected set; get; }

        public virtual bool alive { protected set; get; }

        public virtual void Start()
        {
            current = max;
            alive = true;
        }

        public virtual void Heal(ulong scale)
        {
            HealAnim();
            HealSound();
            var temp = scale + current;
            if (temp >= max)
            {
                current = max;
            }
            else
            {
                current = temp;
            }
        }
        protected virtual void HealAnim() { }
        protected virtual void HealSound() { }

        public virtual void Hurt(ulong scale)
        {
            HurtAnim();
            HurtSound();
            var temp = scale - current;
            if (temp <= 0)
            {
                Die();
            }
            else
            {
                current = temp;
            }
        }
        protected virtual void HurtAnim() { }
        protected virtual void HurtSound() { }

        public virtual IEnumerable Die()
        {
            DieAnim();
            DieSound();
            alive = false;
            yield return new WaitForSeconds(0);
        }
        protected virtual void DieAnim() { }
        protected virtual void DieSound() { }
    }
}
