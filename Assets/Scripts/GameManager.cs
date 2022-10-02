using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public GameManager() : base(false, false) { }

    public const float LOOP_TIME = 10f;

    public float _time = LOOP_TIME;
    public float Time { get { return _time; } }
    public float TimerPercentage => Time / LOOP_TIME;
    public static bool TimerEnabled = false;
    public UnityEvent TimerComplete;

    public int SoulCount = 0;
    public int SoulGoal = 1;
    public float SoulsPercentage => Mathf.Clamp01(SoulCount / SoulGoal);

    public int Coins = 0;

    public bool ShowStartDayButton = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TimerEnabled)
        {
            _time -= UnityEngine.Time.deltaTime;
            if (_time <= 0)
            {
                _time = LOOP_TIME;
                TimerComplete.Invoke(); //TODO remove?

                if (SoulCount < SoulGoal)
                {
                    Debug.Log("fail!");
                    //TODO strikes or fail harder
                }
                SoulCount = 0;
                //TODO increase soulgoal
            }
        }
    }
}
