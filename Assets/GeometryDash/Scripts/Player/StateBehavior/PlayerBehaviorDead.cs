using System;
using UnityEngine.SceneManagement;
using UnityEngine;
public class PlayerBehaviorDead :  IPlayerBehavior
{
    public bool NeedFixedUpdate { get ; set ; } = false;

    private Player _player;
    public  void Enter(Player player)
    {
        _player = player;
        Debug.Log("Enter DEAD behavior");
        DoDead();
    }
    private void DoDead(){
        if(_player.gameObject.GetComponent<MeshRenderer>().enabled){
            _player.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        return;
    }
    public void Exit()
    {    
        Debug.Log("Exit DEAD behavior");
        SceneManager.LoadScene(0);
    }

    public void FixedUpdate()
    {
    }
}