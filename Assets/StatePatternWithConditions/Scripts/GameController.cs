using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StatePattern {
	public class GameController : MonoBehaviour {

		List<Enemy> enemies = new List<Enemy>();

		private GameObject PlayerObj;

		void Start () {
			PlayerObj = GameObject.FindGameObjectWithTag("Player");
			GameObject CrawlerObj = GameObject.FindGameObjectWithTag("Crawler");
			GameObject CreeperObj = GameObject.FindGameObjectWithTag("Creeper");
			enemies.Add(new Crawler(CrawlerObj.transform));
			enemies.Add(new Creeper(CreeperObj.transform));
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