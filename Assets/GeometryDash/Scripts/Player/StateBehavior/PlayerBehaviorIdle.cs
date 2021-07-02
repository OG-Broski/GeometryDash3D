
using UnityEngine;
public class PlayerBehaviorIdle : IPlayerBehavior
{
    public PlayerBehaviorIdle()
    {
    }
    public bool NeedFixedUpdate { get ; set ; } = false;
    public void Enter(Player player)
    {
        
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        DoIdle();
    }

    private void DoIdle(){
        Debug.Log("Щось єбать робиться пока хуй знає");
    }
}
