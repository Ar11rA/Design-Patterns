using UnityEngine;
using System.Collections;

namespace StatePatternWithClasses
{
	public abstract class State
	{
		protected Enemy enemy;
		protected float health;
		protected float distance;

		public float Health
		{
			get { return health; }
			set { health = value; }
		}

		public abstract void UpdateEnemy(Transform PlayerObj);
		public abstract void doAction(Transform PlayerObj);
	}
}