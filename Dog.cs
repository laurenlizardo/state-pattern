using System;
using System.Collections;

public class Dog
{
    // Public Fields
    public string Name;

    // Basic Statistics
    public BasicStatistic Health = new BasicStatistic (10 );
    public BasicStatistic Hunger = new BasicStatistic( 10 );
    public BasicStatistic Thirst = new BasicStatistic( 10 );
    public BasicStatistic WalkSpeed = new BasicStatistic( 5 );

    // States
    private StateMachine _stateMachine;
    public StateMachine StateMachine => _stateMachine;

    // Constructors
    public Dog() { }
    public Dog( string name ) { Name = name; }

    // Methods
    public virtual void Initialize()
    {
        _stateMachine = new StateMachine();
        _stateMachine.SetState( new Idle() );

        Update();
    }

    private void Update()
    {
        while( true )
        {
            Hunger.Deplete( .5f );
            Thirst.Deplete( .1f );
        }
    }
}

public class Idle : IState
{
    public Idle() : base() { }

    public void Tick() { }
    public void OnEnter() { }
    public void OnExit() { }
}

public class Walk : IState
{
    public Walk() : base() { }

    public void Tick() { }
    public void OnEnter() { }
    public void OnExit() { }
}

public class Eat : IState
{
    public Eat() : base() { }

    public void Tick() { }
    public void OnEnter() { }
    public void OnExit() { }
}

public class Sleep : IState
{
    public Sleep() : base() { }

    public void Tick() { }
    public void OnEnter() { }
    public void OnExit() { }
}

public class Statistic { }
public class BasicStatistic : Statistic
{
    // Constructors
    public BasicStatistic() { }
    public BasicStatistic( float value ) { Value = value; }

    // Fields and Properties
    public float Value;

    // Methods
    public void Deplete( float depletionSpeed )
    {
        Value -= depletionSpeed * Time.time;
    }
}