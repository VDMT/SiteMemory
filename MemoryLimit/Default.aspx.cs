using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Caching;

namespace MemoryLimit
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGetSystemInfo_Click(object sender, EventArgs e)
        {
            bool is64bitProcess = Environment.Is64BitProcess;
            long workingSetMemoryMB = Environment.WorkingSet / (1024 * 1024);
            int threadID = Environment.CurrentManagedThreadId;
            Version ver = HttpRuntime.IISVersion;
            int itemsInCache = Cache.Count;
            var bytesAvailableForCacheMB = Cache.EffectivePrivateBytesLimit / (1024 * 1024);
            var percentageOfPhysicalMemLimit = Cache.EffectivePercentagePhysicalMemoryLimit;
            var memCacheLimit = MemoryCache.Default.CacheMemoryLimit / (1024 * 1024);
            var cacheName = MemoryCache.Default.Name;
            var memCachePhsycialLimitPercentage = MemoryCache.Default.PhysicalMemoryLimit;
            
            lblIs64Bit.Text = is64bitProcess ? "64bit Process" : "32bit Process";
            string version = string.Format("{0}.{1}.{2}", ver.Major, ver.Minor, ver.Build);
            lblIISVersion.Text = string.Format("IIS Version: {0}", version); 
            lblMemoryFillAmount.Text = string.Format("Working Set Memory (MB): {0}",Convert.ToString(workingSetMemoryMB));
            lblItemsInCache.Text = string.Format("Items in Cache: {0}", itemsInCache.ToString());
            lblAvailableForCacheMB.Text = string.Format("MB Availble for Cache: {0}", bytesAvailableForCacheMB.ToString());
            lblPercentageOfPhysicalMemLimit.Text = string.Format("Percentage of Physical Memory Limit: {0}%", percentageOfPhysicalMemLimit.ToString());
            lblMemoryCacheLimit.Text = string.Format("Memory that can be used by Cache: {0}MB", memCacheLimit);
            lblMemoryCachePhysicalLimitPercentage.Text = string.Format("Percentage of Physical memory limit: {0}%", memCachePhsycialLimitPercentage);
        }

        protected void btnGetFileContent_Click(object sender, EventArgs e)
        {
            string lorem = string.Empty;
            try
            {
                var localPath = HttpRuntime.AppDomainAppPath;
                lorem = File.ReadAllText(localPath + "\\lorem.txt");
            }
            catch (Exception ex)
            {
                ErrorDiv.InnerHtml = "ERROR: <br />" + ex.Message;
            }

            try
            {
                AddToCach(lorem);
            }
            catch (Exception ex)
            {
                ErrorDiv.InnerHtml = "ERROR: <br />" + ex.Message;
            }

        }

        private void AddToCach(string item)
        {
            item = item + item + item + item + item;
            Random rnd = new Random();
            Mem.AddToCache(item, rnd.Next());
        }

        protected void btnClearCache_Click(object sender, EventArgs e)
        {
            MemoryCache.Default.Dispose();
        }
    }
}