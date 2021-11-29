using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace DevMarcos.UI.Site.Extensions
{
    public class EmailTagHelper : TagHelper
    {
        public string EmailDomain { get; set; } = "devmarcos.com.br";
        public string labelLink { get; set; } = "Email";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + EmailDomain;

            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(labelLink);
        }

    }
}
