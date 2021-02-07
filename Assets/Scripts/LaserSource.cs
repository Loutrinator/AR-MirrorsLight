using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{
	public int maxBounces = 10;
	public LineRenderer laser;

	private int _mirrorLayer;
	private int _blockerLayer;

	private List<Vector3> _positions = new List<Vector3>();

	private void Awake()
	{
		_mirrorLayer = LayerMask.NameToLayer("Mirror");
		_blockerLayer = LayerMask.NameToLayer("Blocker");
	}

	private void FixedUpdate()
	{
		ComputeLaser();
	}

	private void ComputeLaser()
	{
		_positions.Clear();
		_positions.Add(laser.transform.position);

		ShootRaycast(maxBounces, transform.right);
			
		laser.positionCount = _positions.Count;
		laser.SetPositions(_positions.ToArray());
	}

	private void ShootRaycast(int boncesLeft, Vector3 forward)
	{
		if (boncesLeft == 0)
		{
			return;
		}

		int mask = (1 << _mirrorLayer) | (1 << _blockerLayer);
		if (Physics.Raycast(_positions[_positions.Count - 1], forward, out RaycastHit hit, 10f, mask))
		{
			_positions.Add(hit.point);
			if (hit.transform.gameObject.layer == _mirrorLayer)
			{
				//v1 = -2 * (v0 . N) * N + v0
				Vector3 v0 = forward.normalized;
				Vector3 v1 = Vector3.Reflect(v0, hit.normal); //-2 * Vector3.Dot(v0,hit.normal) * hit.normal + v0;
				ShootRaycast(boncesLeft-1, v1);
			}
		}
		else
		{
			_positions.Add(forward * 1000);
		}
	}
}