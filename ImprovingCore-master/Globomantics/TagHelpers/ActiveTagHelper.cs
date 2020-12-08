using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "active-url")]
    public class ActiveTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor httpService;

        public string ActiveUrl { get; set; }

        public ActiveTagHelper(IHttpContextAccessor httpService)
        {
            this.httpService = httpService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (httpService.HttpContext.Request.Path.ToString().Contains(ActiveUrl))
            {
                var existingAttrs = output.Attributes["class"]?.Value;
                output.Attributes.SetAttribute("class",
                    "active " + existingAttrs.ToString());
            }
        }
    }
}
