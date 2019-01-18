using System.Collections.Generic;

namespace Graph.Components.Navigation
{
	public class NavigationModel
	{
		public IEnumerable<NavigationSection> NavigationSections { get; set; }
	}

	public class NavigationSection : NavigationItem
	{
		public bool IsActive { get; set; }
		public IEnumerable<NavigationItem> NavigationItems { get; set; }
	}

	public class NavigationItem
	{
		public string Title { get; set; }
		public string Url { get; set; }
	}
}