using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Graph.Components.Navigation
{
	using System.Configuration;

	public class NavigationSurfaceController : SurfaceController
	{
		public ActionResult Index()
		{
			var topNavigation = new NavigationModel();
			var home = new UmbracoHelper(UmbracoContext.Current).TypedContentSingleAtXPath($"//{ConfigurationManager.AppSettings[nameof(NavigationConfig.HomePageAlias)]}");
			var navSections = home.Children
				.Where(x => x.GetPropertyValue<bool>(ConfigurationManager.AppSettings[nameof(NavigationConfig.HideFromNavigationPropertyAlias)]) == false)
				.ToList();
			var sections = new List<NavigationSection>();

			var contentSections = navSections
				.Select(navSection =>
				{
					var sectionItems = navSection.Children
						.Where(item => item.GetPropertyValue<bool>(ConfigurationManager.AppSettings[nameof(NavigationConfig.HideFromNavigationPropertyAlias)]) == false)
						.ToList();
					var isActive = navSection.Id == UmbracoContext.Current.PageId
									|| sectionItems.Any(item => item.Id == UmbracoContext.Current.PageId);

					return new NavigationSection
					{
						Title = navSection.Name,
						Url = navSection.Url,
						NavigationItems = sectionItems
							.Select(item =>
								new NavigationItem
								{
									Title = item.Name,
									Url = item.Url
								}),
						IsActive = isActive
					};
				}).ToList();

			sections.AddRange(contentSections);
			topNavigation.NavigationSections = sections;

			return View("/Components/Navigation/Views/Navigation.cshtml", topNavigation);
		}
	}
}