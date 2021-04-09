using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BeamHolderTest
{
    public class BeamHolder : MonoBehaviour
    {
        [SerializeField] private GameObject _beamHolder;
        [SerializeField] private GameObject _crane;
        [SerializeField] private GameObject _hook;

        private void Awake()
        {
            _beamHolder = this.gameObject;
            _crane = this.transform.Find("Crane").gameObject;
            _hook = _crane.transform.Find("Hook").gameObject;
        }

        public void MoveBeamHolder()
        {
            _beamHolder.transform.position = new Vector3(_beamHolder.transform.position.x, _beamHolder.transform.position.y, Mathf.Lerp(_beamHolder.transform.position.z, _beamHolder.transform.position.z + 1, 0.1f));
        }

        public void MoveCrane()
        {
            _crane.transform.position = new Vector3(Mathf.Lerp(_crane.transform.position.x, _crane.transform.position.x + 1, 0.1f), _crane.transform.position.y, _crane.transform.position.z);
        }

        public void MoveHook(float m)
        {
            _hook.transform.position = new Vector3(_hook.transform.position.x, Mathf.Lerp(_hook.transform.position.y, _hook.transform.position.y + m * 0.01f, 1), _hook.transform.position.z);
        }
    }
}
