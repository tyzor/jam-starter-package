using UnityEngine;

namespace Utilities.WaitForAnimations.Base
{

    public interface IWaitForAnimation
    {
        Coroutine DoAnimation(float time, ANIM_DIR animDir);
    }
}