using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Animator PlayerAnimator;
    CharacterController characterController;
    Coroutine JumpCoroutine;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        GameManager.Instance.Jump += OnJump;
        GameManager.Instance.CurrentJumpFactor = GameManager.Instance.MinJumpFactor;

    }
    private void OnDestroy()
    {
        GameManager.Instance.Jump -= OnJump;

    }

    private void OnJump()
    {
        if (!Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonUp(0))
        {
            JumpCoroutine = StartCoroutine(Jump());
        }

    }



    IEnumerator Jump()
    {
        float startPosY = transform.position.y;
        GameManager.Instance.IsJump = true;
        Vector3 target = transform.forward * (2.5f / GameManager.Instance.CurrentJumpFactor);
        target.y += (2.5f / GameManager.Instance.CurrentJumpFactor);

        while (transform.position.y < startPosY + GameManager.Instance.CurrentJumpFactor)
        {
            characterController.Move(target * Time.deltaTime * 200f * (GameManager.Instance.CurrentJumpFactor / 10f));
            //transform.position = Vector3.MoveTowards(transform.position, transform.position + target, Time.fixedUnscaledDeltaTime * 10f);
            yield return null;
        }
        GameManager.Instance.CurrentJumpFactor = GameManager.Instance.MinJumpFactor;
        GameManager.Instance.IsJump = false;
        GameManager.Instance.IsGrounded = false;

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            if (JumpCoroutine != null)
            {
                StopCoroutine(JumpCoroutine);
                GameManager.Instance.IsJump = false;
            }

        }
    }
}
