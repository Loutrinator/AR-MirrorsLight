using UnityEngine;

namespace Interactor
{
    public class SplitterInteractor : MonoBehaviour, ILaserInteractor
    {
        public void OnHit(RaycastHit hit, Laser laser)
        {
            Vector3 leftDir = Quaternion.AngleAxis(-60, transform.up) * -transform.right;
            Vector3 rightDir = Quaternion.AngleAxis(60, transform.up) * -transform.right;
            
            laser.CastChild(transform.position + transform.up * 0.05522725f + leftDir * 0.02f, leftDir);
            laser.CastChild(transform.position + transform.up * 0.05522725f + rightDir * 0.02f, rightDir);
        }
    }
}