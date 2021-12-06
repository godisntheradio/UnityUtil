using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace UnityUtil.Management
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Response;

        private void OnEnable()
        { Event.RegisterListener(this); }

        private void OnDisable()
        { Event.UnregisterListener(this); }

        public void OnEventRaised()
        { Response.Invoke(); }
    }
}
