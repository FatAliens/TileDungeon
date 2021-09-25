using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TimerManager), typeof(Slider))]
public class SliderTimer : MonoBehaviour
{
    [SerializeField] private float m_duration;
    private Timer _timer;
    private TimerManager _manager;
    private Slider _slider;

    private void Start()
    {
        _manager = GetComponent<TimerManager>();
        _slider = GetComponent<Slider>();

        _timer = new Timer(m_duration, false, TimerCompleted, UpdateTimer);
        _manager.RegisterTimer(_timer);
    }

    private void UpdateTimer(Timer timer)
    {
        _slider.value = timer.RatioComplete;
    }

    private void TimerCompleted(Timer timer)
    {
        Debug.Log("Completed!");
    }

    public void RestartTimer()
    {
        _timer.Restart();
    }
}
