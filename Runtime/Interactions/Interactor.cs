using Lucky44.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lucky44.Util.Interaction
{
    /// <summary>
    /// The 'Interactor' is a Singleton and will shoot rays out of the Main-Camera (Assigned by Unity) to check if the player is hovering over
    /// an 'Interactable'
    /// </summary>

    public class Interactor : Singleton<Interactor>
    {
        [SerializeField]
        private float maxInteractDist = 5f;

        private Interactable current = null;

        private void Update()
        {
            //Checks if the player hovers over an Interactbale
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxInteractDist))
            {
                Interactable interactable = hit.transform.gameObject.GetComponent<Interactable>();
                if (interactable != null)
                {
                    //If there is an Interactable script on the object, check if it isn't the one we just had then set evrything accordingly
                    if (current != interactable)
                    {
                        if (current != null)
                            current.OnEndHover();

                        current = interactable;
                        current.OnBeginHover();
                    }
                }
                else
                {
                    //If there isn't an Interactable script on the object, invalidate our current one
                    if (current != null)
                    {
                        current.OnEndHover();
                        current = null;
                        return;
                    }
                }
            }
            else
            {
                //If the ray hits nothing, we are no longer hovering over an Interactable
                if (current != null)
                {
                    current.OnEndHover();
                    current = null;
                    return;
                }
            }


            //Calls the 'OnHover' method, if there is a currently hovered object
            if (current == null)
                return;

            current.OnHover();
        }

        ///<summary>Call this when the player presses the interact button</summary>
        public void TriggerInteraction()
        {
            if (current == null)
                return;

            current.OnInteract();
        }
    }
}
