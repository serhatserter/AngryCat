using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    public Animator PlayerAnimator;
    public GameObject TrailEffect;
    CharacterController characterController;

    AudioSource dashHop;
    // Start is called before the first frame update
    void Start()
    {
        dashHop = GameManager.Instance.AudioSources.GetChild(1).GetComponent<AudioSource>();

        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsJump && Input.GetKeyDown(KeyCode.W) && !GameManager.Instance.IsDash)
        {
            PlayerAnimator.SetTrigger("IsDash");
            StartCoroutine(WaitDash());
        }
    }

    IEnumerator WaitDash()
    {
        GameManager.Instance.IsDash = true;
        TrailEffect.SetActive(true);
        dashHop.Play();

        float start = Time.time;
        float speed = GameManager.Instance.PlayerSpeed * 6f;

        while (Time.time - start < 0.15f)
        {
            characterController.Move(transform.forward * 350 * Time.deltaTime * GameManager.Instance.PlayerSpeed);
            yield return null;
        }
        GameManager.Instance.PlayerSpeed = speed / 6f;
        yield return new WaitForSeconds(0.25f);
        GameManager.Instance.IsDash = false;
        TrailEffect.SetActive(false);

    }
}
