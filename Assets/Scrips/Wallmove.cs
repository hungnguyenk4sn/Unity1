using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallmove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float oldPosition;
 

    void Start()
    {
        moveSpeed = 2 ;
        minY = -14.3f;
        maxY = -9f;
        oldPosition = 120f;
       
    }


    void Update()
    {
        transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("ResetWall"))
        {
            transform.localPosition = new Vector3(oldPosition, Random.Range(minY, maxY), 0);
        };
    }
   

}
