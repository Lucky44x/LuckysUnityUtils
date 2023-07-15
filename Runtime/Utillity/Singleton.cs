using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lucky44.Util
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T I
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<T>();
                if (instance == null)
                    Debug.LogError("Singleton of type " + typeof(T) + "wasn't found");
                return instance;
            }
        }

        public virtual void Awake()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            if (this.GetType() != typeof(T))
            {
                Debug.LogError("Singleton of type " + typeof(T) + " was passed the wrong parameter");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.delayCall -= DestroySelf;
        UnityEditor.EditorApplication.delayCall += DestroySelf;
#endif
            }

            if (instance == null)
                instance = this as T;
            else if (instance != this)
            {
                Debug.LogError("Singleton of type " + typeof(T) + " has two instances. Destroying one.");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.delayCall -= DestroySelf;
        UnityEditor.EditorApplication.delayCall += DestroySelf;
#endif
            }
        }

        private void DestroySelf()
        {
            if (Application.isPlaying)
                Destroy(this);
            else
                DestroyImmediate(this);
        }
    }
}
