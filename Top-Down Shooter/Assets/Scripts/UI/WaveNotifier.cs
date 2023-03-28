using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveNotifier : MonoBehaviour
{
    [SerializeField]
    private string _currentWaveText;

    private int waveHighscore;

    public string CurrentWaveText
    {
        get
        {
            return _currentWaveText;
        }
        set
        {
            _currentWaveText = value;
            OnChange?.Invoke();
        }
    }

    private void Start()
    {
        waveHighscore = PlayerPrefs.GetInt("waveHighscore", waveHighscore);
    }

    public void SetWave(int currentWave, int maxWave)
    {
        if(currentWave > waveHighscore)
            waveHighscore = currentWave;

        CurrentWaveText = $"{currentWave} / {maxWave}";
    }

    public void SetMaxWave()
    {
        PlayerPrefs.SetInt("waveHighscore", waveHighscore);
    }

    public UnityEvent OnChange;
}
