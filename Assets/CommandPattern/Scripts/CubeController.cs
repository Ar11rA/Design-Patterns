using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern {
	public class CubeController : MonoBehaviour {

		private List<Command> commands = new List<Command>();
		public MovementCalculator moveCalculator = new MovementCalculator ();
		private int current = 0;

		public void Redo (int numberOfCommands) {
			for (int i = 0; i < numberOfCommands; i++)
			{
				if (current < commands.Count - 1)
				{
					Command command = commands[current++];
					command.Execute();
				}
			}	
		}
		
		public void Undo (int numberOfCommands) {
			for (int i = 0; i < numberOfCommands; i++)
			{
				if (current > 0)
				{
					Command command = commands[--current] as Command;
					command.UnExecute();
				}
			}
		}

		public void Compute(string movementType, float distance)
		{
			Command command = new MovementCommand(moveCalculator, movementType, distance);
			command.Execute();
			commands.Add(command);
			current++;
		}
	}
}	