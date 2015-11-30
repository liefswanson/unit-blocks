using UnityEngine;
using System.Collections;

namespace UnitBlocks
{
    namespace Platformer
    {
        // FIXME currently just a semantic class
        public abstract class Controller : MonoBehaviour
        {
            public abstract void Start();
            public abstract void Update();
        }
    }
}
