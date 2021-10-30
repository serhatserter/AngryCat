using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UISlide : MonoBehaviour
{
    public float delay = 0f;

    public Transform target;
    public float duration = 1f;
    private Vector3 orjPos;

    public Ease ease = Ease.InSine;
    IEnumerator Start()
    {
        orjPos = transform.position;
        transform.position = target.position;

        yield return new WaitForSeconds(delay);

        transform.DOMove(orjPos, duration).OnComplete(() =>
        {
            this.enabled = false;
        }).SetEase(ease).OnComplete(() => this.enabled = false);
    }

}
