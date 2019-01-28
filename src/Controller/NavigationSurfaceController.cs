using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;

namespace Graph.Components.Navigation
{
	public class NavigationSurfaceController : SurfaceController
	{
		public ActionResult Index()
		{
			var home = new UmbracoHelper(UmbracoContext.Current).TypedContent(NavigationConfig.HomePageId);
			var navigation = new NavigationModel
			{
				Branches = GetBranches(home, home.Children.Where(GetFilteredChildren).ToArray())
			};

			return View("/App_Plugins/NavigationBlock/Views/Navigation.cshtml", navigation);
		}

		private static IEnumerable<NavigationItem> GetBranches(IPublishedContent parent, IPublishedContent[] items)
		{
			return items
				.Where(x => x.Parent.Id == parent.Id)
				.OrderBy(x => x.SortOrder)
				.Select(x => new NavigationItem
				{
					IsActive = CheckIsActive(x, items),
					Title = x.Name,
					Url = x.Url,
					Level = x.Level - 1,
					Branches = NavigationConfig.NavigationDeepLevel > x.Level - 1 
								? GetBranches(x, x.Children.Where(GetFilteredChildren).ToArray()) 
								: null
				});
		}

		private static bool GetFilteredChildren(IPublishedContent item)
		{
			return item.IsVisible();
		}

		private static bool CheckIsActive(IPublishedContent navSection, IEnumerable<IPublishedContent> sectionItems)
		{
			return navSection.Id == UmbracoContext.Current.PageId
				   || sectionItems.Any(item => item.Id == UmbracoContext.Current.PageId);
		}
	}
}