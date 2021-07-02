
using System;
using UnityEngine;
public class PlayerBehaviorMove :  IPlayerBehavior
{
    public bool NeedFixedUpdate { get; set; } = true;
    private PlayerData _playerData = PlayerData._singleton;
    [SerializeField] public Player _player;
    [SerializeField] private Rigidbody _rigidBody;
    public void Enter(Player player)
    {
        if(_rigidBody == null){
            _rigidBody = player.GetComponent<Rigidbody>();
            _player = player;
        }
        
    }
    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            _playerData._doJump = true;
        }
    }
    public void FixedUpdate()
    {
        DoMove();
    }
    
    public void Exit()
    {
        Debug.Log("EXIT MOVE behavior ");
    }

    
    private void DoMove(){
     
        Vector3 _moveVector = Vector3.right;
        _moveVector = _moveVector.normalized *_playerData._moveSpeed * Time.deltaTime;
        _rigidBody.MovePosition(_player.transform.position + _moveVector);  
        
        if(_playerData._isJumping){
                _playerData._doJump= false;
                _player.transform.Rotate(Vector3.back * _playerData._rotateSpeed);
                }
        else if(_playerData._doJump) {
                _playerData._doJump = false;
                _playerData._isJumping = true;
                _rigidBody.AddForce(new Vector2(0,Physics.gravity.y / _playerData._defaulGravity) * _playerData._jumpForse);
                _playerData._jumpForse = _playerData._minJumpForse;
                Quaternion _rotation = _player.transform.rotation;
                _rotation.z =  (float)Math.Round(_rotation.z / _playerData._rotateAngle) * _playerData._rotateAngle;
                _player.transform.rotation = _rotation;

        }
        
        if(_rigidBody.velocity.y < 0){
                    _rigidBody.velocity += Vector3.up * Physics.gravity.y *(_playerData._fallMultiplier - 1) * Time.deltaTime;
        }
        else if(_rigidBody.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space)){
        _rigidBody.velocity += Vector3.up * Physics.gravity.y * (_playerData._lowjumpMultiplier- 1) * Time.deltaTime; 
        }

 }

}