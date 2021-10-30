using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class FinalDoorController : MonoBehaviour
{
    public Image Dark;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("TRIGGER");
            Dark.gameObject.SetActive(true);

            Dark.DOFade(1, 1f).SetEase(Ease.InSine).OnComplete(() =>
            {

                Time.timeScale = 0;

                if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) SceneManager.LoadScene(1);
                else if (SceneManager.GetActiveScene().buildIndex == 0) SceneManager.LoadScene(2);
                else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


            });
        }
    }
}
