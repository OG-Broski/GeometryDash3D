public interface IPlayerBehavior {

    bool NeedFixedUpdate { get; set;}
    
    void Enter(Player player);

    void FixedUpdate();

    
    void Exit();
}