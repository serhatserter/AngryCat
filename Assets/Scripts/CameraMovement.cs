using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private void Update()
    {
        //if (!GameManager.Instance.IsJump) transform.position = Vector3.SmoothDamp(transform.position, GameManager.Instance.Player.position, ref velocity ,  0.1f);
        if (!GameManager.Instance.IsJump) transform.position = Vector3.Lerp(transform.position, GameManager.Instance.Player.position, Time.deltaTime * 20f);

    }

    void LateUpdate()
    {
        if (GameManager.Instance.IsJump) transform.position = Vector3.Lerp(transform.position, GameManager.Instance.Player.position, Time.deltaTime * 10f);
    }
}
