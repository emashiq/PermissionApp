using Microsoft.AspNetCore.Mvc;
using PermissionApp.DbItems;
using System.Collections.Generic;
using System.Linq;

namespace PermissionApp.Controllers
{
    public class UserUIPermissionController : Controller
    {
        private readonly UIControlDatabaseContext _context;
        public UserUIPermissionController(UIControlDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index(string currentUrl)
        {
            string userId = "1"; // Get UserID from IIdentity
            ModuleUi moduleUI = _context.ModuleUi.FirstOrDefault(x => x.Url == currentUrl);
            if (moduleUI.IsOpen)
            {
                return Json(new { IsOpen = true, data = "", IsPermitted = true });
            }

            UserModuleUi userModuleUI = _context.UserModuleUi.FirstOrDefault(x => x.ModuleUiid == moduleUI.Id);
            if (userModuleUI == null)
            {
                return Json(new { IsOpen = true, data = "", IsPermitted = false });
            }

            if (userModuleUI.HasFullAccess)
            {
                return Json(new { IsOpen = true, data = "", IsPermitted = true });
            }

            List<UserModuleUicontrolsPermissions> permittedItems = _context.UserModuleUicontrolsPermissions.Where(x => x.ModuleUiid == moduleUI.Id && x.UserId == userId).ToList();
            return Json(new { IsOpen = moduleUI.IsOpen, data = permittedItems, IsPermitted = true });
        }
    }
}