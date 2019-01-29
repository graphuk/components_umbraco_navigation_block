using System.Web;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace Graph.Components.Navigation
{
	public class ClearNavigationCacheHandler : ApplicationEventHandler
	{
		public ClearNavigationCacheHandler()
		{
			ContentService.Published += ContentPublishedEvent;
			ContentService.UnPublished += ContentPublishedEvent;
			ContentService.Deleted += ContentDeletedEvent;
		}

		private static void ContentPublishedEvent(IPublishingStrategy sender, PublishEventArgs<IContent> e)
		{
			ClearNavigation();
		}

		private static void ContentDeletedEvent(IContentService sender, DeleteEventArgs<IContent> e)
		{
			ClearNavigation();
		}

		private static void ClearNavigation()
		{
			HttpContext.Current.Cache.Remove("Navigation");
		}
	}
}
