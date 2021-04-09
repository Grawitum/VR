using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BeamHolderTest
{
    public class ButtonController : MonoBehaviour
    {
        private Button _up;
        private Button _down;
        private Button _east;
        private Button _west;
        private Button _north;
        private Button _south;

        private void Awake()
        {
            _up = this.transform.Find("UpButton").gameObject.GetComponent<Button>();
            _down = this.transform.Find("DownButton").gameObject.GetComponent<Button>();
            _east = this.transform.Find("EastButton").gameObject.GetComponent<Button>();
            _west = this.transform.Find("WestButton").gameObject.GetComponent<Button>();
            _north = this.transform.Find("NorthButton").gameObject.GetComponent<Button>();
            _south = this.transform.Find("SouthButton").gameObject.GetComponent<Button>();
        }
        void Start()
        {

        }

        void Update()
        {

        }
    }
}
