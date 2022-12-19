using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFX : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private AnimationCurve _scaleAnimation;

    [ContextMenu("Play Animations")]

    public void PlayAnimation(Transform jumper, float duration)
    {
        StartCoroutine(AnimationByTime(jumper,duration));
    }
    private IEnumerator AnimationByTime(Transform jumper, float duration)
    {
        var expiredSeconds = 0f;
        var progress = 0f;

        Vector3 startPosition = jumper.position;
        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress=expiredSeconds/duration;

            jumper.position=startPosition+new Vector3(0, _yAnimation.Evaluate(progress),0);
            jumper.localScale = Vector3.one * _scaleAnimation.Evaluate(progress);

            yield return null;
        }
    }
}
