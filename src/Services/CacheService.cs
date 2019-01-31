using System;
using System.Web;
using System.Web.Caching;

namespace Graph.Components.Navigation
{
	public static class CacheService
	{
		public static ICacheStore GetCacheStore(TimeSpan time)
		{
			return new CacheStore(time);
		}

		private class CacheStore : ICacheStore
		{
			private readonly TimeSpan _time;

			public CacheStore(TimeSpan time)
			{
				_time = time;
			}

			public T GetOrLoadValue<T>(string key, Func<T> expression) where T : class
			{
				var cache = HttpContext.Current.Cache;
				if (cache[key] == null) cache.Insert(key, expression(), null, Cache.NoAbsoluteExpiration, _time);

				return cache[key] as T;
			}
		}
	}

	public interface ICacheStore
	{
		T GetOrLoadValue<T>(string key, Func<T> expression) where T : class;
	}
}
