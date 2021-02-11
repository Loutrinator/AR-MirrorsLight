using System;
using UnityEngine;
using UnityEngine.Events;

namespace Interactor
{
	public class RecieverInteractor : MonoBehaviour, ILaserInteractor
	{
		public UnityEvent RecieverActivation;
		public UnityEvent RecieverDesactivation;

		private bool _lastFrameHit;
		private bool _thisFrameHit;

		public MeshRenderer meshRenderer;

		public Material offMaterial;
		public Material onMaterial;

		private void Start()
		{
			RecieverActivation.AddListener(() => meshRenderer.sharedMaterial = onMaterial);
			RecieverDesactivation.AddListener(() => meshRenderer.sharedMaterial = offMaterial);
		}

		public void OnHit(RaycastHit hit, Laser laser)
		{
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
			RecieverActivation.Invoke();
		}

		private void OnDetectorDesactivation()
		{
			RecieverDesactivation.Invoke();
		}
	}
}