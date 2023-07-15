using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lucky44.Util.Animation
{
    public class Animator2D : MonoBehaviour
    {
        [SerializeField]
        bool play = false;

        [SerializeField]
        private AnimationClip2DInterface assignable;
        private AnimationClip2D currentClip = AnimationClip2D.empty;

        private float currentTime;
        private float maxTime;

        private Dictionary<float, Sprite> frames;
        private float lastTime = 0;

        private SpriteRenderer spriteRenderer;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (assignable != null) { setClip(assignable); }
        }

        public void setClip(AnimationClip2D clip)
        {
            if (clip == null)
            {
                Stop();
                return;
            }
            this.currentClip = clip;
            currentTime = 0;
            maxTime = clip.length;
            frames = clip.frames;
            play = true;
        }

        public void setClip(AnimationClip2DInterface clip)
        {
            setClip(clip.converted());
        }

        public void Stop()
        {
            currentClip = AnimationClip2D.empty;
            maxTime = 0;
            frames = null;
            currentTime = 0;
            play = false;
        }

        private void Update()
        {
            if (play)
            {
                if (frames == null)
                    return;

                currentTime += Time.deltaTime;
                foreach (float key in frames.Keys)
                {
                    if (key > currentTime)
                        break;

                    if (lastTime < key && key <= currentTime)
                    {
                        lastTime = key;

                        spriteRenderer.sprite = frames[key];
                    }
                }

                if (currentTime > maxTime)
                {
                    if (!currentClip.loop)
                    {
                        play = false;
                        return;
                    }

                    currentTime = 0;
                    lastTime = 0;
                    spriteRenderer.sprite = frames.First().Value;
                }
            }
        }
    }
}