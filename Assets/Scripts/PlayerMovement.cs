using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public Animator PlayerAnimator;
    CharacterController characterController;
    VariableJoystick variableJoystick;

    bool isDeath;

    AudioSource grassRun;
    void Start()
    {
        GameManager.Instance.Death += OnDeath;
        variableJoystick = GameManager.Instance.VariableJoystick;
        characterController = GetComponent<CharacterController>();

        grassRun = GameManager.Instance.AudioSources.GetChild(0).GetComponent<AudioSource>();
    }


    void OnDestroy()
    {
        GameManager.Instance.Death -= OnDeath;

    }

    void OnDeath()
    {
        isDeath = true;
        GetComponent<DashController>().enabled = false;
        GetComponent<JumpController>().enabled = false;
        PlayerAnimator.SetBool("Death", true);
    }

    Vector3 direction;

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsJump && !isDeath)
        {
            CheckGround();

        }
    }
    private void Update()
    {
        if (!isDeath && !GameManager.Instance.HoldJump)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerAnimator.SetBool("IsRun", true);
                grassRun.Play();
            }
            if (Input.GetMouseButton(0) && !GameManager.Instance.HoldJump)
            {
                direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10f);
                characterController.Move(direction * GameManager.Instance.PlayerSpeed * Time.deltaTime * 300f);

            }
            if (Input.GetMouseButtonUp(0))
            {
                grassRun.Stop();

                PlayerAnimator.SetBool("IsRun", false);
            }
        }


    }

    void CheckGround()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;

        if (!Physics.Raycast(transform.position, -transform.up, out hit, 0.3f, layerMask))
        {

            GameManager.Instance.OnFloor = false;
            characterController.Move(Vector3.down / (100f * Time.fixedDeltaTime));

        }
        else
        {

            GameManager.Instance.OnFloor = true;

        }


    }
}
