using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lucky44.Util.States
{
    public class StateMachine : MonoBehaviour
    {
        List<State> states = new List<State>();

        State currentState = null;

        private void Awake()
        {
            State[] states = GetComponents<State>();
            this.states.AddRange(states);
        }

        public void chooseState(Type t)
        {
            foreach (State s in states)
            {
                if (s.GetType() == t)
                {
                    initState(s);
                }
            }
        }

        private void initState(State s)
        {
            if (currentState != null)
                currentState.StateEnd();

            currentState = s;
            currentState.StateStart(this);
        }

        public virtual void Update()
        {
            if (currentState != null)
                currentState.StateUpdate();
        }
    }
}
