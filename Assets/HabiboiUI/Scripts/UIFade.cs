using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UIFade : MonoBehaviour
{
    public float delay = 0f;
    public float duration = 1f;
    public TMP_Text[] texts;
    public Image[] images;
    IEnumerator Start()
    {
        //images = GetComponentsInChildren<Image>();
        //texts = GetComponentsInChildren<TMP_Text>();

        yield return new WaitForSeconds(delay);

        foreach (Image image in images)
        {
            float firstA = image.color.a;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
            image.DOFade(firstA, duration);
        }

        foreach (TMP_Text text in texts)
        {
            float firstA = text.color.a;
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
            text.DOFade(firstA, duration);
        }

        this.enabled = false;
    }
}
