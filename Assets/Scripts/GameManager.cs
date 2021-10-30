using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    public VariableJoystick VariableJoystick;
    public Transform CamParent;
    public Transform Player;

    [Range(0, 1)] public float PlayerSpeed;
    [Range(0, 20f)] public float BarSpeed;
    public float CurrentJumpFactor;
    public float MaxJumpFactor, MinJumpFactor;
    
    public float FloorPoint;
    public bool IsJump;
    public bool OnFloor;
    public bool IsDash;
    public bool IsGrounded;
    public bool HoldJump;
    public bool IsDeath;

    public Action Jump;
    public Action Death;

    public Transform AudioSources;
}
