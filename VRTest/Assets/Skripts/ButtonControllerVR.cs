using System;
using UnityEngine;

namespace BeamHolderTest
{
    public class ButtonControllerVR : MonoBehaviour
    {
        private GameObject _up;
        private GameObject _down;
        private GameObject _east;
        private GameObject _west;
        private GameObject _north;
        private GameObject _south;
        private Action del;
        private BeamHolder bh;

        private void Awake()
        {
            _up = this.transform.Find("UpButton").gameObject;
            _down = this.transform.Find("DownButton").gameObject;
            _east = this.transform.Find("EastButton").gameObject;
            _west = this.transform.Find("WestButton").gameObject;
            _north = this.transform.Find("NorthButton").gameObject;
            _south = this.transform.Find("SouthButton").gameObject;
            bh = FindObjectOfType<BeamHolder>();
        }
        void Start()
        {
            del = bh.MoveUpHook;
            _up.gameObject.AddComponent<Buttons>().SetAction(del);
            del = bh.MoveDownHook;
            _down.gameObject.AddComponent<Buttons>().SetAction(del);
            del = bh.MoveRightCrane;
            _east.gameObject.AddComponent<Buttons>().SetAction(del);
            del = bh.MoveLeftCrane;
            _west.gameObject.AddComponent<Buttons>().SetAction(del);
            del = bh.MoveForwardBeamHolder;
            _north.gameObject.AddComponent<Buttons>().SetAction(del);
            del = bh.MoveBackBeamHolder;
            _south.gameObject.AddComponent<Buttons>().SetAction(del);
        }
    }
}

