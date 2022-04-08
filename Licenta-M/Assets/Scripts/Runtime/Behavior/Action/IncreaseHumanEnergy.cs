using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task increase energy for human.")]
	[TaskCategory("ActorModel/Increase")]
	public class IncreaseHumanEnergy : BaseAction<HumanController>
	{
		private float lastTime;
		[RequiredField] public SharedUtilityScore ScoreToLock1;
		[RequiredField] public SharedUtilityScore ScoreToLock2;
		[RequiredField] public SharedUtilityScore ScoreToLock3;

		public override void OnStart()
		{
			base.OnStart();
			lastTime = Time.time;
		}

		public override TaskStatus OnUpdate()
		{
			ScoreToLock1.Value = new UtilityScore(ScoreToLock1.Value.Score, true);
			ScoreToLock2.Value = new UtilityScore(ScoreToLock2.Value.Score, true);
			ScoreToLock3.Value = new UtilityScore(ScoreToLock3.Value.Score, true);

			if (Time.time - lastTime > 0.2f && Actor.Model.Energy.Value < 98f)
			{
				Actor.Model.Energy.Value += 2.0f;
				lastTime = Time.time;
			}

			if (Actor.Model.Energy.Value > 95f)
			{
				ScoreToLock1.Value = new UtilityScore(ScoreToLock1.Value.Score, false);
				ScoreToLock2.Value = new UtilityScore(ScoreToLock2.Value.Score, false);
				ScoreToLock3.Value = new UtilityScore(ScoreToLock3.Value.Score, false);
				return TaskStatus.Success;
			}

			return TaskStatus.Running;
		}
	}
}
