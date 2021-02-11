using UnityEngine;

public abstract class LevelManagerBase : MonoBehaviour
{
	public int mirrorlimit = 1;
	protected GameManager _gameManager;
	
	public void SetGameManager(GameManager gameManager)
	{
		_gameManager = gameManager;
	}
}
