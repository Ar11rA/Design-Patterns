using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern {
	
	public class MovementCalculator  {

		private GameObject cube;
		private Vector3 position;

		public void GetNewPosition (string movementType, float distance) {
			cube = GameObject.FindGameObjectWithTag ("Player");
			position = cube.transform.position;
			switch (movementType) {
			case "MoveForward":
				position.x = cube.transform.position.x + distance;
				break;
			case "MoveBackward":
				position.x = cube.transform.position.x - distance;
				break;
			case "MoveLeft":
				position.z = cube.transform.position.z + distance;
				break;
			case "MoveRight":
				position.z = cube.transform.position.z - distance;
				break;
			default:
				Debug.Log ("Invalid Option");
				break;
			}
			cube.transform.position = position;
		}			
	}
}