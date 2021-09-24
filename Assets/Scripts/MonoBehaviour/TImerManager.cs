using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private List<Timer> _timers = new List<Timer>();

    private List<Timer> _timersToAdd = new List<Timer>();

    public void RegisterTimer(Timer timer)
    {
        _timersToAdd.Add(timer);
    }

    public void CancelAllTimers()
    {
        foreach (Timer timer in _timers)
        {
            timer.Cancel();
        }

        _timers = new List<Timer>();
        _timersToAdd = new List<Timer>();
    }

    public void PauseAllTimers()
    {
        foreach (Timer timer in _timers)
        {
            timer.Pause();
        }
    }

    public void ResumeAllTimers()
    {
        foreach (Timer timer in _timers)
        {
            timer.Resume();
        }
    }

    private void Update()
    {
        UpdateAllTimers();
    }

    private void UpdateAllTimers()
    {
        if (_timersToAdd.Count > 0)
        {
            _timers.AddRange(_timersToAdd);
            _timersToAdd.Clear();
        }

        foreach (Timer timer in _timers)
        {
            timer.Update();
        }

        _timers.RemoveAll(t => t.IsDone);
    }
}