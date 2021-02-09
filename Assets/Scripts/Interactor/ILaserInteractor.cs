using UnityEngine;

namespace Interactor
{
	public interface ILaserInteractor
	{
		void OnHit(RaycastHit hit, Laser laser);
	}
}
