using System.Collections.Generic;
using Interactor;
using UnityEngine;

public class LevelManager : LevelManagerBase
{
    public List<RecieverInteractor> _recievers = new List<RecieverInteractor>();

    private int _activatedRecievers;

    private void Start()
    {
        foreach (RecieverInteractor reciever in _recievers)
        {
            reciever.RecieverActivation.AddListener(Activated);
            reciever.RecieverDesactivation.AddListener(Desactivated);
        }
    }

    private void Activated()
    {
        _activatedRecievers++;
        
        if (_activatedRecievers > _recievers.Count)
        {
            Debug.LogError("_activatedRecievers too big, resetting to _recievers.Count");
            _activatedRecievers = _recievers.Count;
        }

        if (_activatedRecievers == _recievers.Count)
        {
            Win();
        }
    }

    private void Desactivated()
    {
        _activatedRecievers--;
        
        if (_activatedRecievers < 0)
        {
            Debug.LogError("_activatedRecievers is negative, resetting to 0");
            _activatedRecievers = 0;
        }
    }

    public void Win()       
    {
        _gameManager.Win();
    }
}
