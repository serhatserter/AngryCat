using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObstaclesController : MonoBehaviour
{
    public enum ObstacleTypes
    {
        HorizontalWall,
        VerticalWall,
        ForwardFloor,

    }

    public ObstacleTypes Type;
    public float Range;
    public float MoveTime;
    void Start()
    {
        ;

        if (Type == ObstacleTypes.HorizontalWall)
        {
            transform.DOMove(transform.position + (transform.right * Range), MoveTime).SetEase(Ease.InOutExpo).SetLoops(-1, LoopType.Yoyo);
        }
        else if (Type == ObstacleTypes.VerticalWall)
        {
            transform.DOMove(transform.position + (transform.up * Range), MoveTime).SetEase(Ease.InOutExpo).SetLoops(-1, LoopType.Yoyo);

        }
        else if (Type == ObstacleTypes.ForwardFloor)
        {
            transform.DOMove(transform.position + (transform.forward * Range), MoveTime).SetEase(Ease.InOutExpo).SetLoops(-1, LoopType.Yoyo);

        }

    }


}
