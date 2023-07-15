using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lucky44.Util.Interaction
{
    /// <summary>
    /// The Interactable is a inheritable class with functions for 'OnBeginHover', 'OnHover', 'OnEndHover' and 'OnInteract'
    /// </summary>
    public class Interactable : MonoBehaviour
    {
        /// <summary>
        /// Gets called the first frame the camera hovers over this object
        /// </summary>
        public virtual void OnBeginHover()
        {

        }


        /// <summary>
        /// Gets called every frame the camera is hovering over this object
        /// </summary>
        public virtual void OnHover()
        {

        }

        /// <summary>
        /// Gets called when the player stops hovering over this object
        /// </summary>
        public virtual void OnEndHover()
        {

        }

        /// <summary>
        /// Gets called when the player is hovering over this object and the Interactor's 'TriggerInteract' event gets called
        /// </summary>
        public virtual void OnInteract()
        {

        }
    }
}
