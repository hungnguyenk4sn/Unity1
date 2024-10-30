using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
   
     Rigidbody2D _rigi;
    [SerializeField] float speed1, jump;
    bool isGround;
    [SerializeField] PlayerState _playerState = PlayerState.IDEL;
    [SerializeField] AnimationControllerBase _anim;
   

    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
       
    }

    
    void Update()
    {
        Move();
        UpdateState();
        _anim.UpdateAnomation(_playerState);
    }

    void UpdateState()
    {
        if (!isGround)
        {
          
            _playerState = PlayerState.JUMP;
        }
        else
        {
            if (_rigi.velocity.x != 0)
            {
                _playerState = PlayerState.RUN;
            }
            else
            {
                _playerState = PlayerState.IDEL;
            }
        }
        
    }

    void Move()
    {
        _rigi.velocity = new Vector2(Input.GetAxis("Horizontal") * speed1, _rigi.velocity.y);
        if (_rigi.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
       
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
           isGround = false;
            _rigi.AddForce(new Vector2(0, jump));
          
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        if (collision.gameObject.CompareTag("endgame"))
        {
            GameManager.instance.EndGame();
        }


        /* RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 2f);
         Debug.DrawRay(this.transform.position, Vector2.down * 2, Color.red);
         if (hit.collider != null)
         {
             isGround =true;

         }*/



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
           
           
        {
            GameManager.instance.CollectScore();
        }
    }

    /*rivate void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("endgame"))
        {
            GameManager.instance.EndGame();
        }
    }*/

    public enum PlayerState
    {
        IDEL, 
        RUN,
        JUMP



    }
}
