using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FirstStartGame : MonoBehaviour
{
    public GameObject Panel;
    public Transform CamPos;


    public PlayerMovement PlayerMovement;
    public DashController DashController;
    public JumpController JumpController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickButton()
    {
        Panel.SetActive(false);

        Camera.main.transform.DORotate(CamPos.eulerAngles, 1f);
        Camera.main.transform.DOLocalMove(CamPos.localPosition, 1f).OnComplete(() =>
        {

            PlayerMovement.enabled = true;
            DashController.enabled = true;
            JumpController.enabled = true;

        });
    }
}
