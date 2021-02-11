using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public List<GameObject> levelPrefabs;
	public Transform levelTargetTransform;
	public List<GameObject> mirrors;
	public MainMenuManager mainUI;
	public LevelManagerBase CurrentLevel { get; private set; }
	private int levelPos = 0;
	
	public bool MainTargetFound { get; private set; } = false;

	public void Start()
	{
	}
	
	public void Win()
	{
		Debug.Log("Win!");
		mainUI.ShowWin();
	}

	public void Play()
	{
		StartGame(levelPos);
	}

	public void StartGame(int pos)
	{
		CurrentLevel = Instantiate(levelPrefabs[pos], levelTargetTransform).GetComponent<LevelManagerBase>();
		CurrentLevel.SetGameManager(this);
		int mirrorLimit = CurrentLevel.mirrorlimit;
		for (int i = 0; i < mirrors.Count; i++)
		{
			if (i < mirrorLimit)
			{
				mirrors[i].SetActive(true);
			}
			else
			{
				mirrors[i].SetActive(false);
			}
		}
	}
	public void LoadNextLevel()
	{
		Destroy(CurrentLevel.gameObject);
		CurrentLevel = null;
		levelPos++;
		StartGame(levelPos);
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