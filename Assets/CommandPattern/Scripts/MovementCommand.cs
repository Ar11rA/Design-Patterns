using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern {
	public class MovementCommand : Command {

		private string movementType;
		private float distance;
		private MovementCalculator moveCalculator;

		public MovementCommand(MovementCalculator moveCalculator, string movementType, float distance)
		{
			this.moveCalculator = moveCalculator;
			this.movementType = movementType;
			this.distance = distance;
		}

		public string MovementType
		{
			set { movementType = value; }
		}

		public float Distance
		{
			set { distance = value; }
		}


		public override void Execute () {
			moveCalculator.GetNewPosition (movementType, distance);
		}

		public override void UnExecute () {
			moveCalculator.GetNewPosition (Undo(movementType), distance);
		}
			
		private string Undo(string movementType)
		{
			switch (movementType)
			{
			case "MoveForward": 
				return "MoveBackward";
				break;
			case "MoveBackward": 
				return "MoveForward";
				break;
			case "MoveLeft": 
				return "MoveRight";
				break;
			case "MoveRight": 
				return "MoveLeft";
				break;
			default:
				return "InvalidOption";
				break;
			}
		}
	}
}