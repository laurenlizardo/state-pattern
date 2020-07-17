public class StateMachine
{
    // Constructors
    public StateMachine() { }

    // Fields
    private IState _currentState = null;

    public void OnEnter() { }
    public void Tick() { }
    public void OnExit() { }

    public void SetState( IState state )
    {
        _currentState = state;
    }

    public IState GetState()
    {
        return _currentState;
    }
}