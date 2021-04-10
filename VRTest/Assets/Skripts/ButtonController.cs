using UnityEngine;
using UnityEngine.UI;
using System;

namespace BeamHolderTest
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField]private Button _up;
        private Button _down;
        private Button _east;
        private Button _west;
        private Button _north;
        private Button _south;
        private Action del;
        private BeamHolder bh;

        private void Awake()
        {
            _up = this.transform.Find("UpButton").gameObject.GetComponent<Button>();
            _down = this.transform.Find("DownButton").gameObject.GetComponent<Button>();
            _east = this.transform.Find("EastButton").gameObject.GetComponent<Button>();
            _west = this.transform.Find("WestButton").gameObject.GetComponent<Button>();
            _north = this.transform.Find("NorthButton").gameObject.GetComponent<Button>();
            _south = this.transform.Find("SouthButton").gameObject.GetComponent<Button>();
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
