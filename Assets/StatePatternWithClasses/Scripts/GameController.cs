using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StatePatternWithClasses {
	public class GameController : MonoBehaviour {

		List<Enemy> enemies = new List<Enemy>();

		private GameObject PlayerObj;

		void Start () {
			PlayerObj = GameObject.FindGameObjectWithTag("Player");
			GameObject EnemyObj = GameObject.FindGameObjectWithTag("Enemy");
			enemies.Add(new Enemy(EnemyObj.transform));
			enemies.Add(new Enemy(EnemyObj.transform));
			}

		// Update is called once per frame
		void Update () {
			for (int i = 0; i < enemies.Count; i++)
			{
				enemies[i].UpdateEnemy(PlayerObj.transform);
			}
		}
	}
}