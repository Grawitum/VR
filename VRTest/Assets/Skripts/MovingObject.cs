using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeamHolderTest
{
    public class MovingObject : MonoBehaviour
    {
        [SerializeField]private bool _isConnected;
        private GameObject _connectObject;
        //[SerializeField]private bool _isFloor = true;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //if (_isFloor)
            //{
                //_isFloor = false;
                if (_isConnected)
                {
                    this.transform.position = _connectObject.transform.position;
                }
            //}
        }

        public void Connected(GameObject connectObject)
        {
            _connectObject = connectObject;
            //this.transform.position = _connectObject.transform.position;
            _isConnected = true;
            //_isFloor = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isConnected)
            {
                if (other.CompareTag("Building"))
                {
                    _isConnected = false;
                    _connectObject.gameObject.GetComponentInParent<Hook>().Disconnect(); //GetParentComponent<Hook>().Disconnect();
                }
            }
        }
    }
}
