using System;
using UnityEngine;

public class Timer
{
    public float Duration { get; private set; }
    public bool IsLooped { get; set; }
    public bool IsCompleted { get; private set; }
    public bool IsPaused { get; private set; }
    public float TimeElapsed { get; private set; }
    public float TotalTimeElapsed { get; private set; }

    public float StartTime => _startTime;
    public float LastUpdateTime => _lastUpdateTime;

    public event Action<Timer> OnComplete;
    private event Action<Timer> OnUpdate;

    private readonly float _startTime;
    private float _lastUpdateTime;

    public Timer(float duration, Action<Timer> onComplete, Action<Timer> onUpdate,
        bool isLooped)
    {
        this.Duration = duration;
        this.OnComplete = onComplete;
        this.OnUpdate = onUpdate;
        this.IsLooped = isLooped;

        _startTime = worldTime;
        _lastUpdateTime = _startTime;
    }

    public void Pause()
    {
        IsPaused = true;
    }

    public void Resume()
    {
        IsPaused = false;
    }

    public float GetTimeElapsed()
    {
        if (IsCompleted || GetWorldTime() >= GetFireTime())
        {
            return Duration;
        }

        return GetWorldTime() - _startTime;
    }

    public float GetTimeRemaining()
    {
        return Duration - GetTimeElapsed();
    }

    public float GetRatioComplete()
    {
        return GetTimeElapsed() / Duration;
    }

    public float GetRatioRemaining()
    {
        return GetTimeRemaining() / Duration;
    }

    private float worldTime => Time.realtimeSinceStartup;

    private float fireTime => _startTime + Duration;

    private float timeDelta => worldTime - _lastUpdateTime;

    private void Update()
    {
        if (IsCompleted)
        {
            return;
        }

        if (!IsPaused)
        {
            _startTime += GetTimeDelta();
            _lastUpdateTime = GetWorldTime();
            return;
        }

        _lastUpdateTime = GetWorldTime();

        if (_onUpdate != null)
        {
            _onUpdate(GetTimeElapsed());
        }

        if (GetWorldTime() >= GetFireTime())
        {
            if (_onComplete != null)
            {
                _onComplete();
            }

            if (IsLooped)
            {
                _startTime = GetWorldTime();
            }
            else
            {
                IsCompleted = true;
            }
        }
    }
}