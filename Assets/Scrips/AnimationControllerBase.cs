using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState = PlayController.PlayerState;

public class AnimationControllerBase : MonoBehaviour
{
    Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>(); 
    }

   
    void Update()
    {
      
    }
    public void UpdateAnomation( PlayerState playerState)
    {
        for(int i=0; i <= (int)PlayerState.JUMP; i++)
        {
            string stateName = ((PlayerState)i).ToString();
           
            if (playerState == (PlayerState)i)
            {
                _animator.SetBool(stateName, true);
            }
            else
            {
                _animator.SetBool(stateName, false);
            }
         
        }
    }

}
