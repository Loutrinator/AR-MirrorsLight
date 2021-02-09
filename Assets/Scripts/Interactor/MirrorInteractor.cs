using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Interactor
{
	public class MirrorInteractor : MonoBehaviour, ILaserInteractor
	{
		public void OnHit(RaycastHit hit, Laser laser)
		{
			laser.CastChild(hit.point, Vector3.Reflect(laser.transform.forward, hit.normal));
		}
	}
}