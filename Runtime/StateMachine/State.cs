using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lucky44.Util.States
{
    public class State : MonoBehaviour
    {
        internal StateMachine parent;

        public virtual void StateUpdate()
        {

        }

        public virtual void StateStart(StateMachine parent)
        {
            this.parent = parent;
        }

        public virtual void StateEnd()
        {

        }
    }
}
