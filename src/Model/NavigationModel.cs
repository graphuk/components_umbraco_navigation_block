using System.Collections.Generic;

namespace Graph.Components.Navigation
{
	public class NavigationModel
	{
		public IEnumerable<NavigationItem> Branches { get; set; }
	}

	public class NavigationItem
	{
		public string Title { get; set; }
		public string Url { get; set; }
		public bool IsActive { get; set; }
		public int Level { get; set; }
		public IEnumerable<NavigationItem> Branches { get; set; }
	}
}