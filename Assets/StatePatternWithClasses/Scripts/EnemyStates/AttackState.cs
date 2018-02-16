using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePatternWithClasses
{
	public class AttackState : State {

		public AttackState(float health, Enemy enemy) {
			this.health = health;
			this.enemy = enemy;
		}

		public override void UpdateEnemy(Transform PlayerObj) {
			float distance = (enemy.enemyObj.position - PlayerObj.position).magnitude;
			checkState (health, distance);
		}

		public override void doAction(Transform PlayerObj) {
			Debug.Log ("Attack");
		}

		private void checkState(float health, float distance)
		{
			if (health < 20f) {
				enemy.State = new FleeState (this.health, this.enemy);
			} else if (distance < 2f) {
				enemy.State = new MoveToPlayerState (this.health, this.enemy);
			}
		}
	}
}