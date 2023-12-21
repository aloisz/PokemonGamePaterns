using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerPokemon : MonoBehaviour
{
	public Actor currentActor;

	private ICommand moveStraightCommand;
	private ICommand moveDownCommand;
	private ICommand moveRightCommand;
	private ICommand moveLeftCommand;

	private Stack<ICommand> stack;

	private void Awake()
	{
		stack = new Stack<ICommand>();
		moveStraightCommand = new MoveStraightCommand();
		moveDownCommand = new MoveDownCommand();
		moveRightCommand = new MoveRightCommand();
		moveLeftCommand = new MoveLeftCommand();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) // UP
        {
			moveStraightCommand.Execute(currentActor);
			stack.Push(moveStraightCommand);
		}
        if (Input.GetKeyDown(KeyCode.S)) // Down
        {
	        moveDownCommand.Execute(currentActor);
	        stack.Push(moveDownCommand);
        }
        if (Input.GetKeyDown(KeyCode.D)) // Right
        {
	        moveRightCommand.Execute(currentActor);
	        stack.Push(moveRightCommand);
        }
        if (Input.GetKeyDown(KeyCode.A)) // Left
        {
	        moveLeftCommand.Execute(currentActor);
	        stack.Push(moveLeftCommand);
        }
    }

    public void UndoAction(int numberOfUndoAction) // Undo Action => return where you came from
    {
	    StartCoroutine(CoroutineUndoAction(numberOfUndoAction));
    }

    IEnumerator CoroutineUndoAction(int numberOfUndoAction)
    {
	    for (int i = 0; i < numberOfUndoAction; i++)
	    {
		    stack.Pop().Undo(currentActor);
		    yield return new WaitForSeconds(.1f);
	    }
	    stack.Clear();
    }
    


    public interface ICommand // ALl Commands available
	{
		void Execute(Actor actor);
		void Undo(Actor actor);
	}
	public class MoveStraightCommand : ICommand
	{
		public void Execute(Actor actor)
		{
			actor.MoveStraight();
		}
		public void Undo(Actor actor)
		{
			actor.MoveDown();
		}
	}
	public class MoveDownCommand : ICommand
	{
		public void Execute(Actor actor)
		{
			actor.MoveDown();
		}
		public void Undo(Actor actor)
		{
			actor.MoveStraight();
		}
	}
	
	public class MoveRightCommand : ICommand
	{
		public void Execute(Actor actor)
		{
			actor.TurnRight();
		}
		public void Undo(Actor actor)
		{
			actor.TurnLeft();
		}
	}
	
	public class MoveLeftCommand : ICommand
	{
		public void Execute(Actor actor)
		{
			actor.TurnLeft();
		}
		public void Undo(Actor actor)
		{
			actor.TurnRight();
		}
	}

	
}
public abstract class Actor : MonoBehaviour
{
	public abstract void MoveStraight();
	public abstract void MoveDown();
	public abstract void TurnRight();
	public abstract void TurnLeft();
}



