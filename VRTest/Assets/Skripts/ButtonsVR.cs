using HTC.UnityPlugin.ColliderEvent;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeamHolderTest
{
    public class ButtonsVR : MonoBehaviour, IColliderEventPressEnterHandler
    {
        private Action _myAction;

        private ColliderButtonEventData.InputButton m_activeButton = ColliderButtonEventData.InputButton.Trigger;
        private HashSet<ColliderButtonEventData> pressingEvents = new HashSet<ColliderButtonEventData>();
        public ColliderButtonEventData.InputButton activeButton { get { return m_activeButton; } set { m_activeButton = value; } }

        public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            if (eventData.button == m_activeButton && eventData.clickingHandlers.Contains(gameObject) && pressingEvents.Add(eventData) && pressingEvents.Count == 1)
            {
                _myAction();
            }
        }

        internal void SetAction(Action action)
        {
            _myAction = action;
        }
    }
}
