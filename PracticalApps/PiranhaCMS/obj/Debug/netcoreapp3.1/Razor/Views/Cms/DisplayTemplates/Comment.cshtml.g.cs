#pragma checksum "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d9eb7a1b30b0fc4c6e80ddd9c5df84316b4895a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cms_DisplayTemplates_Comment), @"mvc.1.0.view", @"/Views/Cms/DisplayTemplates/Comment.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\_ViewImports.cshtml"
using Piranha.AspNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\_ViewImports.cshtml"
using PiranhaCMS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d9eb7a1b30b0fc4c6e80ddd9c5df84316b4895a", @"/Views/Cms/DisplayTemplates/Comment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9545d59e323aede8f06f7bdc48a50c454a1b9e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Cms_DisplayTemplates_Comment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Piranha.Models.Comment>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"row comment mb-4\">\n    <div class=\"col-2\">\n        <img class=\"rounded img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 124, "\"", 170, 1);
#nullable restore
#line 5 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
WriteAttributeValue("", 130, WebApp.GetGravatarUrl(Model.Email, 160), 130, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 171, "\"", 190, 1);
#nullable restore
#line 5 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
WriteAttributeValue("", 177, Model.Author, 177, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n    </div>\n    <div class=\"col-10\">\n");
#nullable restore
#line 8 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
         if (!string.IsNullOrEmpty(Model.Url))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h5><a");
            BeginWriteAttribute("href", " href=\"", 304, "\"", 321, 1);
#nullable restore
#line 10 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
WriteAttributeValue("", 311, Model.Url, 311, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 10 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
                                                Write(Model.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> - <small>");
#nullable restore
#line 10 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
                                                                           Write(Model.Created.ToLongDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></h5>\n");
#nullable restore
#line 11 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h5>");
#nullable restore
#line 14 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
           Write(Model.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - <small>");
#nullable restore
#line 14 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
                                  Write(Model.Created.ToLongDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></h5>\n");
#nullable restore
#line 15 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>\n            ");
#nullable restore
#line 17 "c:\Dotnet\Rgbetanco\Repos\PracticalApps\PiranhaCMS\Views\Cms\DisplayTemplates\Comment.cshtml"
       Write(Model.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </p>\n    </div>\n</div>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Piranha.AspNetCore.Services.IApplicationService WebApp { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Piranha.Models.Comment> Html { get; private set; }
    }
}
#pragma warning restore 1591
