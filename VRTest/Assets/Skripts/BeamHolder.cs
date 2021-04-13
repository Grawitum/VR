using UnityEngine;

namespace BeamHolderTest
{
    public sealed class BeamHolder : MonoBehaviour
    {
        private GameObject _beamHolder;
        private const float _speedForwardBeamHolder = 0.1f;
        private const float _speedBackBeamHolder = 0.1f;
        private float _stopPointBeamHolder = 9.5f;

        private GameObject _crane;
        private const float _speedLeftCrane = 0.1f;
        private const float _speedRightCrane = 0.1f;
        private float _stopPointCrane = 50f;

        private GameObject _hook;
        private const float _speedUpHook = 0.1f;
        private const float _speedDownHook = 0.2f;
        private float _stopPointUpHook = 1.5f;
        private float _stopPointDownHook = -3.8f;
        private Vector3 _distanceToHook;
        private float _scaleVire;

        private GameObject _tube;
        private AudioSource _soundRotationTube;
        private const float _speedRotationTube = 5;

        private const float _directionForward = 0.1f;
        private const float _directionBack = -0.1f;

        private GameObject _vire;
        private const float _offsetVire = 0.7f;


        private void Awake()
        {
            _beamHolder = this.gameObject;
            _crane = this.transform.Find("Crane").gameObject;
            _hook = _crane.transform.Find("Hook/hook_base").gameObject;
            _vire = _crane.transform.Find("Hook/Wire_1").gameObject;
            _tube = this.transform.Find("Crane/Tube").gameObject;
            _soundRotationTube = _tube.GetComponent<AudioSource>();
            _distanceToHook = _crane.transform.position - _hook.transform.position;
            _scaleVire = _distanceToHook.y / _vire.transform.localScale.y;
        }

        public void MoveForwardBeamHolder()  
        {
            if (_beamHolder.transform.localPosition.z > -_stopPointBeamHolder)
            {
                MoveBeamHolder(_speedForwardBeamHolder, -_directionForward);
            }
        }

        public void MoveBackBeamHolder() 
        {
            if (_beamHolder.transform.localPosition.z <_stopPointBeamHolder)
            {
                MoveBeamHolder(_speedBackBeamHolder, -_directionBack);
            }
        }

        private void MoveBeamHolder(float speed, float directionOfTravel)
        {
            _beamHolder.transform.position = new Vector3(_beamHolder.transform.position.x, _beamHolder.transform.position.y, Mathf.Lerp(_beamHolder.transform.position.z, _beamHolder.transform.position.z + directionOfTravel, speed));
        }

        public void MoveLeftCrane() 
        {
            if (_crane.transform.localPosition.x < _stopPointCrane)
            {
                MoveCrane(_speedLeftCrane, _directionForward);
            }
        }

        public void MoveRightCrane() 
        {
            if (_crane.transform.localPosition.x > -_stopPointCrane)
            {
                MoveCrane(_speedRightCrane, _directionBack);
            }

        }
        private void MoveCrane(float speed, float directionOfTravel)
        {
            _crane.transform.position = new Vector3(Mathf.Lerp(_crane.transform.position.x, _crane.transform.position.x +directionOfTravel, speed), _crane.transform.position.y, _crane.transform.position.z);
        }

        public void MoveUpHook() 
        {
            if (_hook.transform.localPosition.y < _stopPointUpHook)
            {
                MoveHook(_speedUpHook, _directionForward);
            }
        }

        public void MoveDownHook() 
        {
            if (_hook.transform.localPosition.y > _stopPointDownHook)
            {
                MoveHook(_speedDownHook, _directionBack);
            }
        }

        private void MoveHook(float speed, float directionOfTravel)
        {
            _hook.transform.position = new Vector3(_hook.transform.position.x, Mathf.Lerp(_hook.transform.position.y, _hook.transform.position.y + directionOfTravel, speed), _hook.transform.position.z);
            _distanceToHook = _crane.transform.position - _hook.transform.position;
            _vire.transform.localScale = new Vector3(_vire.transform.localScale.x, _distanceToHook.y/ _scaleVire, _vire.transform.localScale.z);
            _vire.transform.position = new Vector3(_vire.transform.position.x, -_distanceToHook.y / 2 + _offsetVire, _vire.transform.position.z);
            if (!_soundRotationTube.isPlaying)
            {
                _soundRotationTube.Play();
            }
            _tube.transform.Rotate(directionOfTravel * _speedRotationTube, 0, 0);
        }
    }
}
