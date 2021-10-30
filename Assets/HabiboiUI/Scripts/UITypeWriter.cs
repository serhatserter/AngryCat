using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITypeWriter : MonoBehaviour
{
    public float delay = 0f;

    public float duration;
    private float textTime;

    public TextMeshProUGUI text;
    private string story;

    private bool x = true;
    IEnumerator Start()
    {
        story = text.text;
        text.text = "";
        yield return new WaitForSeconds(delay);
        x = false;
    }

    void Update()
    {
        if (!x)
        {
            textTime = duration / story.Length;

            StartCoroutine(PlayText());

            x = true;
        }
    }
    IEnumerator PlayText()
    {
        
        foreach (char c in story)
        {
            text.text += c;
            yield return new WaitForSeconds(textTime);
        }
        this.enabled = false;
    }
}
