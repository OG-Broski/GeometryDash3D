using UnityEngine;
using DG.Tweening;
public class CameraFolow : MonoBehaviour
{
   [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private byte _deadZone = 5;
    [SerializeField] [Range(0.1f,3f)] private float _tweenTime = 1f;

    private float _camY = 0f;
    private float _targetCamY = 0f;
    private float _baseCamY = 0f;
    private sbyte _camStep = 1;
    private bool _isTweeing = false;

private void Start()
{
     _cameraOffset = transform.position - _playerTransform.position;
}
       private void Update()
    {
       if(_playerTransform.position.y > _camStep * _deadZone){
           _targetCamY = _camStep * _deadZone;
           _camStep++;
           _baseCamY= _camY;
       }
       else if(_playerTransform.position.y<(_camStep * _deadZone -_deadZone/2)){
           _camStep --;

           _targetCamY = _camStep * _deadZone;
           _baseCamY=_camY;
       }
       if(_camY != _targetCamY && !_isTweeing){
           DOTween.To(()=>_baseCamY , x =>_camY = x, _targetCamY , _tweenTime).OnComplete(()=>_isTweeing = false);
           _isTweeing = true;
       }
       transform.position = new Vector3(_playerTransform.position.x,_camY,_playerTransform.position.z)+ _cameraOffset;
    }
}
