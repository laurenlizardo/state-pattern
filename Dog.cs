using System;

public class Dog
{
    // Public Fields
    public string Name;

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