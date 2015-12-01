using UnityEngine;
using System.Collections;
using UnitBlocks.Platformer;

namespace UnitBlocks
{
    namespace BlobQuest
    {
        public class PlayerMovement : Movement
        {
            public override void Move(float scale)
            {
                base.Move(scale);
                var movingRight = scale > 0;
                var movingLeft = scale < 0;

                if ((facingRight && movingLeft)
                || (!facingRight && movingRight)) {
                    Turn();
                }
            }
        }
    }
}
