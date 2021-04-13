using HTC.UnityPlugin.ColliderEvent;
using System;
using UnityEngine;

namespace BeamHolderTest
{
    public class ButtonsVR : MonoBehaviour, IColliderEventPressEnterHandler
    {
        private Action _myAction;

        public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
                _myAction();
        }

        internal void SetAction(Action action)
        {
            _myAction = action;
        }
    }
}
