using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lucky44.Util
{
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// performs a bit flag calculation { (1 << layer) & include } and returns true if the result does not equal 0
        /// </summary>
        /// <param name="include"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static bool Contains(this LayerMask include, int layer)
        {
            return (((1 << layer) & include) != 0);
        }
    }
}
