using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lucky44.Util.Effects
{
    public class CameraShaker : Singleton<CameraShaker>
    {
        public void shake(float duration, float magnitude)
        {
            StartCoroutine(shakeNum(duration, magnitude));
        }

        private IEnumerator shakeNum(float duration, float magnitude)
        {
            Vector3 originPos = Camera.main.transform.localPosition;

            float elapsed = 0;

            while(elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;
                Camera.main.transform.localPosition = originPos + new Vector3(x, y, 0);

                elapsed += Time.deltaTime;

                yield return null;
            }

            Camera.main.transform.localPosition = originPos;
        }
    }
}
