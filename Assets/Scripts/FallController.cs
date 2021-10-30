using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class FallController : MonoBehaviour
{
    public Image Dark;

    private void Awake()
    {
        Time.timeScale = 1;
        Dark.DOFade(0, 0.5f).SetDelay(0.5f).OnComplete(() =>
        {

            Dark.gameObject.SetActive(false);

        });

    }

    private void Start()
    {
        GameManager.Instance.Death += OnDeath;
    }

    private void OnDestroy()
    {
        GameManager.Instance.Death -= OnDeath;

    }

    private void OnDeath()
    {
        Retry(1f);
    }

    void Retry(float delay)
    {
        Dark.gameObject.SetActive(true);
        Color red = Color.red;
        red.a = 0f;
        Dark.color = red;
        Dark.DOFade(1, 0.5f).SetDelay(delay).OnComplete(() =>
        {

            Time.timeScale = 0;
            if (SceneManager.GetActiveScene().buildIndex == 0) SceneManager.LoadScene(1);
            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        });
    }

    void Update()
    {
        if (transform.position.y < -5f)
        {
            Retry(0);

        }
    }
}
