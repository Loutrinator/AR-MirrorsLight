public class LevelManager : LevelManagerBase
{
    private GameManager _gameManager;
    
    public void Win()
    {
        _gameManager.Win();
    }

    public override void SetGameManager(GameManager gameManager)
    {
	    _gameManager = gameManager;
    }
}
