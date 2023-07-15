using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lucky44.Util
{
    public static class TransformExtensions
    {
        public static void LookAt2D(this Transform t, Vector2 target)
        {
            Vector2 position = t.position;
            Vector3 diff = target - position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            t.rotation = Quaternion.Euler(0, 0, rot_z - 90);
        }

        public static Transform destroyChildren(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            return transform;
        }

        public static Transform destroyChildrenEditor(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                GameObject.DestroyImmediate(child.gameObject);
            }
            return transform;
        }
    }
}
