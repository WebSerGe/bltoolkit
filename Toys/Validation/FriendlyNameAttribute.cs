using System;

namespace Rsdn.Framework.Validation
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
	public class FriendlyNameAttribute : Attribute
	{
		public FriendlyNameAttribute(string name)
		{
			_name = name;
		}

		private string _name;
		public  string  Name
		{
			get { return _name; }
		}
	}
}
