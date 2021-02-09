using System.Collections.Generic;
using Interactor;
using UnityEngine;

public class Laser : MonoBehaviour
{
	public LineRenderer laserRenderer;
	public GameObject laserPrefab;

	private int _laserInteractorLayer;

	private List<Vector3> _positions = new List<Vector3>();

	private List<GameObject> _children = new List<GameObject>();

	private void Awake()
	{
		_laserInteractorLayer = LayerMask.NameToLayer("LaserInteractor");
	}

	private void Start()
	{
		TraceLaser();
	}

	public void Recalculate()
	{
		OnDestroy();
		TraceLaser();
	}

	public void TraceLaser()
	{
		_positions.Clear();
		
		_positions.Add(laserRenderer.transform.position);
		
		int mask = 1 << _laserInteractorLayer;
		if (Physics.Raycast(_positions[_positions.Count - 1], transform.forward, out RaycastHit hit, 10f, mask))
		{
			_positions.Add(hit.point);

			if (hit.collider.gameObject.TryGetComponent(out ILaserInteractor laser))
			{
				laser.OnHit(hit, this);
			}
		}
		else
		{
			_positions.Add(transform.forward * 1000);
		}
			
		laserRenderer.positionCount = _positions.Count;
		laserRenderer.SetPositions(_positions.ToArray());
	}

	public void CastChild(Vector3 position, Vector3 direction)
	{
		GameObject child = Instantiate(laserPrefab, position, Quaternion.LookRotation(direction));
		_children.Add(child);
	}

	private void OnDestroy()
	{
		foreach (GameObject child in _children)
		{
			Destroy(child);
		}
	}
}