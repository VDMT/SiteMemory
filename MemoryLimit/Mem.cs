using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace MemoryLimit
{
    public class Mem
    {
        public static ObjectCache Cache = null;
        static CacheItemPolicy CachePolicy = null;
        static string CacheString = "FileContents";
        
        static Mem()
        {
            Cache = MemoryCache.Default;
            CachePolicy = new CacheItemPolicy();
        }

        public static void AddToCache(string item, int itemCount)
        {
            Cache.Add(string.Format(CacheString + "{0}", itemCount), item, CachePolicy);
        }
    }
}