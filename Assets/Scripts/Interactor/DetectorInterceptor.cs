using UnityEngine;
using UnityEngine.Events;

namespace Interactor
{
    public class DetectorInterceptor : MonoBehaviour, ILaserInteractor
    {
        public UnityEvent DetectorActivation;
        public UnityEvent DetectorDesactivation;

        private bool _lastFrameHit;
        private bool _thisFrameHit;

        public void OnHit(RaycastHit hit, Laser laser)
        {
            laser.CastChild(hit.point + laser.transform.forward * 0.001f, laser.transform.forward);

            _thisFrameHit = true;
        }

        private void FixedUpdate()
        {
            if (!_lastFrameHit && _thisFrameHit)
            {
                OnDetectorActivation();
            }
            else if (_lastFrameHit && !_thisFrameHit)
            {
                OnDetectorDesactivation();
            }

            _lastFrameHit = _thisFrameHit;
            _thisFrameHit = false;
        }

        private void OnDetectorActivation()
        {
            DetectorActivation.Invoke();
        }

        private void OnDetectorDesactivation()
        {
            DetectorDesactivation.Invoke();
        }
    }
}