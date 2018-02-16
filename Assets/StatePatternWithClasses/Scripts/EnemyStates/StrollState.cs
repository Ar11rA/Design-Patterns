using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePatternWithClasses
{
	public class StrollState : State {

		public StrollState(float health, Enemy enemy) {
			this.health = health;
			this.enemy = enemy;
		}

		public override void UpdateEnemy(Transform PlayerObj) {
			float distance = (enemy.enemyObj.position - PlayerObj.position).magnitude;
			checkState (health, distance);
		}

		public override void doAction(Transform PlayerObj) {
			Vector3 randomPos = new Vector3(Random.Range(0f, 100f), 0f, Random.Range(0f, 100f));
			enemy.enemyObj.rotation = Quaternion.LookRotation(enemy.enemyObj.position - randomPos);
			enemy.enemyObj.Translate(enemy.enemyObj.forward * 20.0f * Time.deltaTime);
		}

		private void checkState(float health, float distance)
		{
			if (distance < 10f)
			{
				enemy.State = new FleeState(this.health, this.enemy);
			}
		}
	}
}