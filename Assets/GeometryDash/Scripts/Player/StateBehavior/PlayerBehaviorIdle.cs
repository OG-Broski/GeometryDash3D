
using System;
using UnityEngine;
public class PlayerBehaviorIdle : IPlayerBehavior
{
    public PlayerBehaviorIdle()
    {
    }
    public bool NeedFixedUpdate { get ; set ; } = false;
    public void Enter(Player player)
    {
        DoIdle();
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    private void DoIdle(){
        Debug.Log("Щось єбать робиться пока хуй знає");
    }
}
