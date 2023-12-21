using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public Actor2 currentActor;

	private ICommand moveStraightCommand;
	private ICommand turnLeftCommand;

	private void Awake()
	{
		moveStraightCommand = new MoveStraightCommand();
		turnLeftCommand = new TurnLeftCommand();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
			moveStraightCommand.Execute(currentActor);
		}
    }


    public interface ICommand
	{
		void Execute(Actor2 actor);
		void Undo(Actor2 actor);
	}
	public class MoveStraightCommand : ICommand
	{
		public void Execute(Actor2 actor)
		{
			actor.MoveStraight();
		}
		public void Undo(Actor2 actor)
		{
			//
		}
	}
	public class TurnLeftCommand : ICommand
	{
		public void Execute(Actor2 actor)
		{
			actor.TurnLeft();
		}
		public void Undo(Actor2 actor)
		{
			//
		}
	}

	
}
public abstract class Actor2 : MonoBehaviour
{
	public abstract void MoveStraight();
	public abstract void TurnLeft();

}


