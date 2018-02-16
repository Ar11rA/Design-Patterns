using UnityEngine;
using System.Collections;

namespace StatePatternWithClasses
{
	public class Enemy 
	{
		public Transform enemyObj;

		private State state;

		public Enemy(Transform enemyObj)
		{
			this.enemyObj = enemyObj;
			this.state = new StrollState(100.0f, this);
		}

		public State State
		{
			get { return state; }
			set { state = value; }
		}

		public void UpdateEnemy(Transform playerObj){
			state.UpdateEnemy (playerObj);
			Debug.Log (this.State.GetType ().Name);
			DoAction (playerObj);
		}

		protected void DoAction(Transform playerObj)
		{
			state.doAction (playerObj);
		}
	}
}

