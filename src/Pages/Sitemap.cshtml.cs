﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SuxrobGM_Website.Pages
{
    public class SitemapModel : PageModel
    {
        private IHostingEnvironment _env;

        public string SitemapContent { get; set; }

        public SitemapModel(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnGet()
        {
            var sitemapFile = System.IO.Path.Combine(_env.WebRootPath, "sitemap.xml");
            SitemapContent = System.IO.File.ReadAllText(sitemapFile);
        }
    }
}