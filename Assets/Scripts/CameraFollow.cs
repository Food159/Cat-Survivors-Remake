using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class CameraFollow : MonoBehaviour
    {
        #region variable
        public Transform target; //target
        public float lerpSpeed = 1.0f; //speed camera

        private Vector3 offset;

        private Vector3 targetPos;
        #endregion
        #region code
        private void Start()
        {
            if (target == null) return;

            offset = transform.position - target.position;
        }

        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }
        #endregion
    }
}
