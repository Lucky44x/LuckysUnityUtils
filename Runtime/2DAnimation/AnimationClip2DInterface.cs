using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lucky44.Util.Animation
{
    [CreateAssetMenu(fileName = "New AnimationClip2DInterface", menuName = "Animation/AnimationClip2DInterface")]
    public class AnimationClip2DInterface : ScriptableObject
    {
        public float length;

        public float[] keys;
        public Sprite[] sprites;

        private AnimationClip2D conv = AnimationClip2D.empty;

        public AnimationClip2D converted()
        {
            //if (conv != AnimationClip2D.empty)
            //    return conv;

            Dictionary<float, Sprite> sprites = new Dictionary<float, Sprite>();
            for (int i = 0; i < keys.Length; i++)
            {
                sprites.Add(keys[i], this.sprites[i]);
            }

            conv = new AnimationClip2D(name, length, sprites);
            return conv;
        }
    }
}
