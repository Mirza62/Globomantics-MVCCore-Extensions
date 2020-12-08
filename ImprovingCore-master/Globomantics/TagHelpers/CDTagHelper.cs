using Globomantics.Core.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("cdrate")]
    public class CDRateTagHelper : TagHelper
    {
        public string Title { get; set; }

        public string MeterPercent { get; set; }

        public CDTermLength TermLength { get; set; }

        private IRateService rateService;

        public CDRateTagHelper(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var rate = rateService.GetCDRateByTerm(TermLength);

            output.Content.SetHtmlContent(
                $@"<div class=""meter"">
                    <p> {Title}</p>
                    <div class = ""progress"">
                            <div class = ""progress-bar bg-info"" style =""width:{MeterPercent}%""></div>
                    </div>
                </div>");

        }

    }
}
