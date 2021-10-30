using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIScale : MonoBehaviour
{
    public float delay = 0f;
    public float duration = .25f;
    public Vector3 startScale = Vector3.zero;
    private Vector3 orjScale;
    IEnumerator Start()
    {
        orjScale = transform.localScale;
        transform.localScale = startScale;
        yield return new WaitForSeconds(delay);
        transform.DOScale(orjScale, duration).OnComplete(() => this.enabled = false);
    }
}
