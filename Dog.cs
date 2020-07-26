using System;
using System.Collections;

public class Dog
{
    // Public Fields
    public string Name;

    // Basic Statistics
    public BasicStatistic Health = new BasicStatistic( 10 );
    public BasicStatistic Hunger = new BasicStatistic( 10 );
    public BasicStatistic Thirst = new BasicStatistic( 10 );

    // States
    private StateMachine _stateMachine;
    public StateMachine StateMachine => _stateMachine;

    // Constructors
    public Dog() { }
    public Dog( string name ) { Name = name; }

    // Events
    public Action OnGameStart;

    // Methods
    public virtual void Initialize()
    {
        _stateMachine = new StateMachine();
        _stateMachine.SetState( new Idle() );

        OnGameStart += Update;

        if ( OnGameStart != null ) OnGameStart();
    }

    private void Update()
    {
        while( true )
        {
            Hunger.Deplete( .5f );
            Thirst.Deplete( .1f );

            if ( Hunger.GetCurrentValue() <= 0 || Thirst.GetCurrentValue() <= 0)
            {
                Health.Deplete(.1f);
            }
        }
    }
}

public class Idle : IState
{
    // Constructors
    public Idle() : base() { }
    
    // Interface Members
    public void Tick() { }
    public void OnEnter() { }
    public void OnExit() { }
}

public class Eating : IState
{
    public BasicStatistic HungerStat;

    // Constructors
    public Eating() : base() { }

    // Interface Members
    public void Tick()
    {
        while ( HungerStat.GetMaxValue() < HungerStat.CurrentValue ) HungerStat.Increase( .1f );
    }
    public void OnEnter() { }
    public void OnExit() { }
}

public class Drinking : IState
{
    // Constructors
    public Drinking() : base() { }

    // Interface Members
    public void Tick() { }
    public void OnEnter() { }
    public void OnExit() { }
}

public class Statistic { }
public class BasicStatistic : Statistic
{
    // Constructors
    public BasicStatistic() { }
    public BasicStatistic( float value ) { _maxValue = value; }

    // Fields and Properties
    private float _maxValue;
    public float CurrentValue { get { return _maxValue; } set { CurrentValue = value; } }

    // Methods
    public void SetValue( float value )
    {
        CurrentValue = value;
    }

    public float GetMaxValue()
    {
        return _maxValue;
    }

    public float GetCurrentValue()
    {
        return CurrentValue;
    }

    public void Deplete( float depletionSpeed )
    {
        CurrentValue -= depletionSpeed;
    }

    public void Increase( float increaseSpeed )
    {
        CurrentValue += increaseSpeed;
    }
}