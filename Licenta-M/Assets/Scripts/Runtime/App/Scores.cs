using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
	public class Scores : MonoBehaviour
	{
		public static float[] EnergyScore { get; private set; }

		private void Start()
		{
			EnergyScore = ReadScore("TestScore");
			foreach (var score in EnergyScore)
			{
				Debug.Log(score);
			}
		}

		private float[] ReadScore(string fileName)
		{
			var textFile = Resources.Load<TextAsset>("Scores/" + fileName);
			string[] firstSplit = textFile.text.Split('\n');
			float[] score = new float[firstSplit.Length];
			score[0] = 1f;
			for (var i = 0; i < firstSplit.Length - 1; i++)
			{
				var secondSplit = firstSplit[i].Split(';');
				score[i + 1] = float.Parse(secondSplit[1]);
			}
			return score;
		}
	}
}


