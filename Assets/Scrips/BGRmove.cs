using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRmove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField]  float moveRange;
    private Vector3 oldPosition;
    
    void Start()
    {
        moveSpeed = 2;
        moveRange = 10;
        oldPosition = transform.position;
    }

   
    void Update()
    {
        WallMove();
    }
    void WallMove()
    {
        transform.Translate(new Vector2(-1 * Time.deltaTime * moveSpeed, 0));

        if (Vector3.Distance(oldPosition, transform.position) > moveRange)
        {
            transform.position = oldPosition;


        }
    }
}
