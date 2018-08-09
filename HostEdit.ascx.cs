using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Client.ClientResourceManagement;
using System;

namespace X3.AdvancedUrlManagement
{
    public partial class HostEdit : PortalModuleBase
    {
        private void Page_Load(System.Object sender, EventArgs e)
        {
            try
            {
                JavaScript.RequestRegistration(CommonJs.jQuery);
                JavaScript.RequestRegistration(CommonJs.jQueryUI);

                ClientResourceManager.RegisterStyleSheet(this.Page, ResolveUrl("https://stackpath.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"), 1);
                ClientResourceManager.RegisterStyleSheet(this.Page, ResolveUrl("/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/plugins/angular-toastr/angular-toastr.min.css"), 1);
                ClientResourceManager.RegisterStyleSheet(this.Page, ResolveUrl("/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/plugins/angular-ui-switch/angular-ui-switch.min.css"), 2);


                ClientResourceManager.RegisterScript(this.Page, ResolveUrl("https://stackpath.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"), 2);
                ClientResourceManager.RegisterScript(this.Page, ResolveUrl("https://ajax.googleapis.com/ajax/libs/angularjs/1.7.2/angular.min.js"), 2);

                ClientResourceManager.RegisterScript(this.Page, ResolveUrl("/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/plugins/angular-toastr/angular-toastr.tpls.min.js"), 5);
                ClientResourceManager.RegisterScript(this.Page, ResolveUrl("/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/plugins/angular-ui-switch/angular-ui-switch.min.js"), 6);

                ClientResourceManager.RegisterScript(this.Page, ResolveUrl("/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/app/app.js"), 7);
                ClientResourceManager.RegisterScript(this.Page, ResolveUrl("/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/app/services/friendly-url.js"), 15);
                ClientResourceManager.RegisterScript(this.Page, ResolveUrl("/DesktopModules/Admin/Dnn.PersonaBar/Modules/X3.AdvancedUrlManagement/app/controllers/host-edit.js"), 20);

            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

    }
}
