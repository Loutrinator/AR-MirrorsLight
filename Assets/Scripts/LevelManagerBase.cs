using UnityEngine;

public abstract class LevelManagerBase : MonoBehaviour
{
	protected GameManager _gameManager;
	
	public void SetGameManager(GameManager gameManager)
	{
		_gameManager = gameManager;
	}
}
