using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIShake : MonoBehaviour
{
    public float delay = 0f;
    public float duration = .25f;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        transform.DOShakePosition(duration, 15, 50, 90).OnComplete(() => this.enabled = false);
    }
}
