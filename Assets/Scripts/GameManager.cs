using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public List<GameObject> levelPrefabs;
	public Transform levelTargetTransform;
	
	private LevelManagerBase _currentLevel;

	public bool MainTargetFound { get; private set; } = false;

	public void Start()
	{
		_currentLevel = Instantiate(levelPrefabs[0], levelTargetTransform).GetComponent<LevelManagerBase>();
		_currentLevel.SetGameManager(this);
	}
	
	public void Win()
	{
		Debug.Log("Win!");
		Destroy(_currentLevel.gameObject);
		_currentLevel = null;
	}

	public void LevelTargetScanned()
	{
		MainTargetFound = true;
	}
	public void LevelTargetLost()
	{
		MainTargetFound = false;
	}
}