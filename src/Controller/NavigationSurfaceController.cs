using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;
using System;

namespace Graph.Components.Navigation
{
	public class NavigationSurfaceController : SurfaceController
	{
		public ActionResult Index()
		{
			var topNavigation = new NavigationModel();
			var home = new UmbracoHelper(UmbracoContext.Current).TypedContentSingleAtXPath($"//{NavigationConfig.HomePageAlias}");
			var navSections = home.Children
				.Where(x => x.GetPropertyValue<bool>(NavigationConfig.HideFromNavigationPropertyAlias) == false)
				.ToList();
			var sections = new List<NavigationSection>();

			var contentSections = navSections
				.Select(MapToNavigationSection).ToList();

			sections.AddRange(contentSections);
			topNavigation.NavigationSections = sections;

			return View("/App_Plugins/Navigation/Views/Navigation.cshtml", topNavigation);
		}

		private static Func<IPublishedContent, NavigationSection> MapToNavigationSection => navSection =>
		{
			var sectionItems = navSection.Children
				.Where(item => item.GetPropertyValue<bool>(NavigationConfig.HideFromNavigationPropertyAlias) == false)
				.ToList();
			var isActive = CheckIsActive(navSection, sectionItems);

			return CreateNavigationSection(navSection, sectionItems, isActive);
		};

		private static bool CheckIsActive(IPublishedContent navSection, List<IPublishedContent> sectionItems)
		{
			return navSection.Id == UmbracoContext.Current.PageId
				   || sectionItems.Any(item => item.Id == UmbracoContext.Current.PageId);
		}

		private static NavigationSection CreateNavigationSection(IPublishedContent navSection, IEnumerable<IPublishedContent> sectionItems, bool isActive)
		{
			return new NavigationSection
			{
				Title = navSection.Name,
				Url = navSection.Url,
				NavigationItems = sectionItems
					.Select(MapToNavigationItem),
				IsActive = isActive
			};
		}

		private static Func<IPublishedContent, NavigationItem> MapToNavigationItem => item => new NavigationItem
		{
			Title = item.Name,
			Url = item.Url
		};
	}
}