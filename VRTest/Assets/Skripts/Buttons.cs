using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BeamHolderTest
{
    public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {   
        private Action _myAction;
        private bool _isDown;

        public void OnPointerDown(PointerEventData eventData)
        {
            this._isDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this._isDown = false;
        }

        void Update()
        {
            if (!this._isDown) return;
            _myAction();
        }

        internal void SetAction(Action action)
        {
            _myAction = action;
        }
    }
}
