﻿using UnityEngine;
using System;

namespace CommandPattern {
	public abstract class Command
	{
		public abstract void Execute();
		public abstract void UnExecute();
	}
}