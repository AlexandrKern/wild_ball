using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animation firstButtonAnimation;
    public Animation secondButtonAnimation;
    public Animation acceleratorButtonAnimation;
    public Animation firstDoorAnimation;
    public Animation secondDoorAnimation;
    public Animation acceleratorAnimation;

    public void PlayAnimation(Animation curentAnimation)
    {
        curentAnimation.Play();
    }
}
