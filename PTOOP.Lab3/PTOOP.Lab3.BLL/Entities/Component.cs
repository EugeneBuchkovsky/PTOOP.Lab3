using System;
namespace PTOOP.Lab3.BLL.Entities
{
	public abstract class Component
	{
		public Component(string name, double conc)
		{
			Name = name;
			Conc = conc;
		}

		public string Name { get; set; }

		public double Conc { get; set; }
	}
}
