using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern {
	public class GameManager : MonoBehaviour {
	
		private CubeController cube;

		void Start () {
			cube = new CubeController ();
			cube.Compute ("MoveForward", 1.0f);
			cube.Compute ("MoveLeft", 0.5f);
			cube.Compute ("MoveBackward", 1.5f);
			cube.Compute ("MoveRight", 0.4f);
			cube.Undo (2);
			cube.Redo (1);
		}
			
	}
}
