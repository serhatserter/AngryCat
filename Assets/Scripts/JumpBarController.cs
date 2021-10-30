using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class JumpBarController : MonoBehaviour
{
    public SlicedFilledImage SlicedFilled;
    public Image OutlineImage;
    public Animator PlayerAnimator;
    public ParticleSystem JumpParticle;

    float startJumpFactor;

    AudioSource jumpAudio, jumpWaitAudio;
    private void Start()
    {
        jumpAudio = GameManager.Instance.AudioSources.GetChild(4).GetComponent<AudioSource>();
        jumpWaitAudio = GameManager.Instance.AudioSources.GetChild(5).GetComponent<AudioSource>();

        startJumpFactor = GameManager.Instance.MaxJumpFactor;
    }
    void Update()
    {
        if (!Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonUp(0)) ReleaseJumpButton();
        FixBarRotation();
        BarOpen();
    }

    void FixBarRotation()
    {
        transform.eulerAngles = Vector3.zero;

    }

    void BarOpen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SlicedFilled.DOFade(0, 0.3f);
            OutlineImage.DOFade(0, 0.3f);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SlicedFilled.DOFade(1f, 0.3f);
            OutlineImage.DOFade(1f, 0.3f);
        }
    }

    void ReleaseJumpButton()
    {
        if (!GameManager.Instance.IsJump && GameManager.Instance.OnFloor)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpWaitAudio.Play();

                JumpParticle.gameObject.SetActive(true);
                GameManager.Instance.HoldJump = true;
                PlayerAnimator.SetBool("Jump1", true);

            }
            else if (Input.GetKey(KeyCode.Space))
            {

                if (GameManager.Instance.CurrentJumpFactor < GameManager.Instance.MaxJumpFactor - 0.5f)
                {
                    GameManager.Instance.CurrentJumpFactor += (GameManager.Instance.BarSpeed * Time.deltaTime * 1.5f);
                    SlicedFilled.fillAmount -= ((GameManager.Instance.BarSpeed * Time.deltaTime * 1.5f) / startJumpFactor);
                }
            }

            else if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpWaitAudio.Stop();

                jumpAudio.Play();
                JumpParticle.gameObject.SetActive(false);


                PlayerAnimator.SetBool("Jump2", true);

                GameManager.Instance.MaxJumpFactor = GameManager.Instance.MaxJumpFactor - GameManager.Instance.CurrentJumpFactor;

                GameManager.Instance.Jump?.Invoke();
            }
            else if (!Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.Instance.CurrentJumpFactor = 0;

                if (GameManager.Instance.MaxJumpFactor < startJumpFactor) GameManager.Instance.MaxJumpFactor += (GameManager.Instance.BarSpeed * Time.deltaTime) / 1;

                if (SlicedFilled.fillAmount < 1f) SlicedFilled.fillAmount += (((GameManager.Instance.BarSpeed * Time.deltaTime) / 1) / startJumpFactor);


            }
        }
    }

    //float BarRatio()
    //{
    //    float ratio = (GameManager.Instance.CurrentJumpFactor/ startJumpFactor );
    //    return SlicedFilled.fillAmount * (1 - ratio);

    //}
}
