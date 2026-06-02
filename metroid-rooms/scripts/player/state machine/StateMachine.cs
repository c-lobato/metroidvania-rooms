using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{
    [Export] public State InitialState;
    [Export] public Player Player;
    public State CurrentState;
    public Dictionary<string, State> States = new();

    public override void _Ready()
    {
        foreach(Node child in GetChildren())
        {
            if(child is State st)
            {
                States[st.Name.ToString().ToLower()] = st;
                st.stateMachine = this;

                //debug de armazenamento de estados no dicionário
                GD.Print($"Estado Armazenado: {child.Name}");
            }
        } 

        if(InitialState != null)
        {
            ChangeState(InitialState.Name.ToString().ToLower());
        }
        
    }        
        
    public void ChangeState (string NewStateName)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit();
        }
        
        //variavel de acesso para um novo estado
        var key = NewStateName.ToLower();

        //verificação de erro 
        if (States.TryGetValue(key, out var newState))
        {
            CurrentState = newState;
        }
        else
        {
            GD.PushWarning($"State '{key}' não registrado."); //(debug)
        }

        //se o estado for válido, ele pode ser definido como novo estado e chamar a função de entrada
        if (CurrentState != null)
        {
            CurrentState.Enter();
        }

    }

    //para logica de timer e animações
	public override void _Process(double delta)
	{
		if (CurrentState != null)
		{
			CurrentState.Update(delta);
		}
	
	}

	//para logica aplicada em fisica
    public override void _PhysicsProcess(double delta)
	{
		if (CurrentState != null)
		{
			CurrentState.PhysicsUpdate(delta);
		}
	}

	//para logica relacionada à inputs no teclado/mouse/controle/...
	public override void _Input(InputEvent @event)
	{
		if (CurrentState != null)
		{
			CurrentState.HandleInput(@event);
		}
	}

  

}
