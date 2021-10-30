using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIRotateZ : MonoBehaviour
{
    public float delay = 0f;
    public float duration = 2.0f;
    public float firstZRot = 359f;
    public bool isLoop = false;
    public RotateMode rotateMode = RotateMode.FastBeyond360;
    private int setLoops = 0;
    private Vector3 orjRot;
    IEnumerator Start()
    {
        if (isLoop)
        {
            setLoops = -1;
        }
        orjRot = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, firstZRot);
        yield return new WaitForSeconds(delay);
        transform.DORotate(orjRot, duration, rotateMode).SetLoops(setLoops).OnComplete(() => this.enabled = false);
    }
}
