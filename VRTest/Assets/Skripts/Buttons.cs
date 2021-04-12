using HTC.UnityPlugin.ColliderEvent;
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

        //test cod..
        //public void OnColliderEventClick(ColliderButtonEventData eventData)
        //{
        //    if (pressingEvents.Contains(eventData) && pressingEvents.Count == 1)
        //    {
        //        SetMenuVisible(!menuVisible);
        //    }
        //}

        //public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        //{
        //    if (eventData.button == m_activeButton && eventData.clickingHandlers.Contains(gameObject) && pressingEvents.Add(eventData) && pressingEvents.Count == 1)
        //    {
        //        buttonObject.position = buttonOriginPosition + buttonDownDisplacement;
        //    }
        //}

        //public void OnColliderEventPressExit(ColliderButtonEventData eventData)
        //{
        //    if (pressingEvents.Remove(eventData) && pressingEvents.Count == 0)
        //    {
        //        buttonObject.position = buttonOriginPosition;
        //    }
        //}


        //test cod..

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
