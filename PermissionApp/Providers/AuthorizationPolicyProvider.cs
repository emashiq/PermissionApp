using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PermissionApp.DbItems;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//This authorization will be added as default authintication scheme
public class AuthorizationHandler : IAuthorizationHandler
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly UIControlDatabaseContext _context;
    public AuthorizationHandler(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
        _context = new UIControlDatabaseContext();
    }
    public Task HandleAsync(AuthorizationHandlerContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            List<IAuthorizationRequirement> pendingRequirements = context.PendingRequirements.ToList();
            HttpContext httpContext = _contextAccessor.HttpContext;
            PathString path = httpContext.Request.Path;
            UserModuleUi userModuleUI = _context.UserModuleUi.Include(x => x.ModuleUi).FirstOrDefault(x => x.ModuleUi.Url == path);
            if (userModuleUI != null)
            {
                if (userModuleUI.IsOpen || userModuleUI.HasFullAccess)
                    pendingRequirements.ForEach(x => context.Succeed(x));
                UserModuleUicontrolsPermissions userControlPermission = _context.UserModuleUicontrolsPermissions.Include(x => x.ModuleUicontrols).FirstOrDefault(c => c.ModuleUicontrols.ControlName == GetControlName(path));
                if (userControlPermission != null)
                    if (userControlPermission.IsPermitted == true)
                        pendingRequirements.ForEach(x => context.Succeed(x));
            }
        }
        
        return Task.CompletedTask;
    }
    // This algorithm must written based on business demand
    private string GetControlName(string path)
    {
        return path;
    }
}