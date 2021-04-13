using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

namespace BeamHolderTest
{
    public class MovingObject : MonoBehaviour, IColliderEventPressEnterHandler
    {
        private bool _isConnected;
        private GameObject _connectObject;

        void Update()
        {
                if (_isConnected)
                {
                    this.transform.position = _connectObject.transform.position;
                }
        }

        public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            _isConnected = false;
        }

        public void Connected(GameObject connectObject)
        {
            _connectObject = connectObject;
            _isConnected = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isConnected)
            {
                if (other.CompareTag("Building"))
                {
                    _isConnected = false;
                    _connectObject.gameObject.GetComponentInParent<Hook>().Disconnect(); 
                }
            }
        }
    }
}
