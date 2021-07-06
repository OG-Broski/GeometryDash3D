
using UnityEngine;
public class PlayerBehaviorIdle : IPlayerBehavior
{
    public PlayerBehaviorIdle()
    {
    }
    public bool NeedFixedUpdate { get ; set ; } = false;
    public void Enter(Player player)
    {
        Debug.Log("Вход в Состояние покоя");
    }

    public void Exit()
    {
        Debug.Log("Выход с Состояние покоя");
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        DoIdle();
    }

    private void DoIdle(){
        Debug.Log("Состояние покоя");
    }
}
