using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            _player.SetBehaviorMove();
        }
        if(Input.GetKeyDown(KeyCode.D)){
            _player.SetBehaviorDead();
        }
        if(Input.GetKeyDown(KeyCode.I)){
            _player.SetBehaviorIdle();
        }
    }
}
