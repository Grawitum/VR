using UnityEngine;

namespace BeamHolderTest
{
    public class Hook : MonoBehaviour
    {
        private bool _isConnected;

        private GameObject _connectPoint;
        private void Awake()
        {
            _connectPoint = this.transform.Find("ConnectPoint").gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_isConnected)
            {
                if (other.CompareTag("MovingObject"))
                {
                    _isConnected = true;
                    other.gameObject.GetComponent<MovingObject>().Connected(_connectPoint);
                }
            }
        }

        public void Disconnect()
        {
            _isConnected = false;
        }
    }
}
