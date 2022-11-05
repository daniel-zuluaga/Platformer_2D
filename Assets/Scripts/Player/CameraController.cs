using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform Background;

    public float minHeight, maxHeight; 

    private Vector2 lastPos;
    public float separation;

    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x + separation, target.position.y, transform.position.z);

        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y); ;

        Background.position = Background.position + new Vector3(amountToMove.x, amountToMove.y, 0f);

        lastPos = transform.position;
    }
}
