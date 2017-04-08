using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace MemoryLimit
{
    public class Mem
    {
        public static MemoryCache Cache = null;
        static CacheItemPolicy CachePolicy = null;
        static string CacheString = "FileContents";

        public static int CacheItemCount
        {
            get { return Cache == null ? 0 : Cache.Count(); }
        }

        static Mem()
        {
            Cache = MemoryCache.Default;
            CachePolicy = new CacheItemPolicy();
        }

        public static void AddToCache(string item, int itemCount)
        {
            Cache.Add(string.Format(CacheString + "{0}", itemCount), item, CachePolicy);
        }

        public static void ClearCache()
        {
            var cnt = Cache.GetCount();
            foreach (var item in Cache.AsQueryable())
            {
                Cache.Remove(item.Key);
            }
            cnt = Cache.GetCount();
        }
    }
}