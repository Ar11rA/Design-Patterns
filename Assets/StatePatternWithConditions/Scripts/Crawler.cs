using UnityEngine;
using System.Collections;


namespace StatePattern
{
	//The crawler class
	public class Crawler : Enemy
	{
		EnemyFSM crawlerMode = EnemyFSM.Stroll;

		float health = 15f;


		public Crawler(Transform crawlerObj)
		{
			base.enemyObj = crawlerObj;
		}


		//Update the crawler's state
		public override void UpdateEnemy(Transform playerObj)
		{
			//The distance between the crawler and the player
			float distance = (base.enemyObj.position - playerObj.position).magnitude;
			Debug.Log ("Crawler");
			Debug.Log (distance);
			switch (crawlerMode)
			{
			case EnemyFSM.Attack:
				if (health < 20f)
				{
					crawlerMode = EnemyFSM.Flee;
				}
				else if (distance > 6f)
				{
					crawlerMode = EnemyFSM.MoveTowardsPlayer;
				}
				break;
			case EnemyFSM.Flee:
				if (health > 60f)
				{
					crawlerMode = EnemyFSM.Stroll;
				}
				break;
			case EnemyFSM.Stroll:
				if (distance < 10f)
				{
					crawlerMode = EnemyFSM.MoveTowardsPlayer;
				}
				break;
			case EnemyFSM.MoveTowardsPlayer:
				//The sCrawler has bow and arrow so can attack from distance
				if (distance < 5f)
				{
					crawlerMode = EnemyFSM.Attack;
				}
				else if (distance > 15f)
				{
					crawlerMode = EnemyFSM.Stroll;
				}
				break;
			}
			Debug.Log ("Crawler Mode");
			Debug.Log (crawlerMode);
			//Move the enemy based on a state
			DoAction(playerObj, crawlerMode);
		}
	}
}