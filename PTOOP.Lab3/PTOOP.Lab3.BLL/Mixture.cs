using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PTOOP.Lab3.BLL.Entities;
using System.Linq;

namespace PTOOP.Lab3.BLL
{
	public class Mixture
	{
		public ObservableCollection<Component> components;
        public List<Type> TypeList = new List<Type>{ typeof(Alcohol), typeof(Caffeine), typeof(CodeinePhosphate), typeof(Hydrocortisone), typeof(SodiumBromide), typeof(Water) };

		public Mixture()
		{
			components = new ObservableCollection<Component>();
		}

		public void AddComponents(string name)
		{
            var type = TypeList.FirstOrDefault(t=>t.Name == name);
            var a = Activator.CreateInstance(type);

			if (typeof(Alcohol).Name == name)
				components.Add(new Alcohol("component1", 0));
			if (typeof(Caffeine).Name == name)
				components.Add(new Caffeine("component1", 0));
			if (typeof(CodeinePhosphate).Name == name)
				components.Add(new CodeinePhosphate("component1", 0));
			if (typeof(Hydrocortisone).Name == name)
				components.Add(new Hydrocortisone("component1", 0));
			if (typeof(SodiumBromide).Name == name)
				components.Add(new SodiumBromide("component1", 0));
			if (typeof(Water).Name == name)
				components.Add(new Water("component1", 0));
		}
	}
}
