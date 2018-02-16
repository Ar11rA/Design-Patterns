using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePatternWithClasses
{
	public class MoveToPlayerState : State {

		public MoveToPlayerState(float health, Enemy enemy) {
			this.health = health;
			this.enemy = enemy;
		}

		public override void UpdateEnemy(Transform PlayerObj) {
			float distance = (enemy.enemyObj.position - PlayerObj.position).magnitude;
			checkState (health, distance);
		}

		public override void doAction(Transform PlayerObj) {
			enemy.enemyObj.rotation = Quaternion.LookRotation(PlayerObj.position - enemy.enemyObj.position);
			enemy.enemyObj.Translate(enemy.enemyObj.forward * 15.0f * Time.deltaTime);
		}

		private void checkState(float health, float distance)
		{
			if (distance < 1f)
			{
				enemy.State = new AttackState (this.health, this.enemy);
			}
			else if (distance > 15f)
			{
				enemy.State = new StrollState (this.health, this.enemy);
			}
		}
	}
}