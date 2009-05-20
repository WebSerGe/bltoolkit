﻿using System;

namespace BLToolkit.Data.Sql
{
	public interface ISqlExpression : IEquatable<ISqlExpression>, ISqlExpressionWalkable
	{
		int Precedence { get; }
	}
}
