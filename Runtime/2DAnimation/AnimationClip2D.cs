using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Lucky44.Util.Animation
{
    [System.Serializable]
    public struct AnimationClip2D
    {
        public bool loop;
        public string name;
        public float length;
        public Dictionary<float, Sprite> frames;

        public AnimationClip2D(string name, float length, Dictionary<float, Sprite> frames, bool loop = true)
        {
            this.name = name;
            this.length = length;
            this.frames = frames;
            this.loop = loop;
        }

        public static readonly AnimationClip2D empty = new AnimationClip2D("_§$NULL", 0, null);

        public static bool operator ==(AnimationClip2D A, AnimationClip2D B)
        {
            bool ret = A.name == B.name && A.length == B.length;
            if (ret)
            {
                if (A.frames == null || B.frames == null)
                {
                    return ret;
                }


                foreach (KeyValuePair<float, Sprite> kvp in A.frames)
                {
                    Sprite compare = null;
                    if (B.frames.TryGetValue(kvp.Key, out compare))
                    {
                        if (!compare == kvp.Value)
                        {
                            ret = false;
                            break;
                        }
                    }
                    else
                    {
                        ret = false;
                        break;
                    }
                }
            }
            return ret;
        }

        public static bool operator !=(AnimationClip2D A, AnimationClip2D B)
        {
            return !(A == B);
        }

        public override bool Equals(object obj)
        {
            if(!(obj is AnimationClip2D))
                return false;

            if (((AnimationClip2D)obj).name == name && ((AnimationClip2D)obj).length == length)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
