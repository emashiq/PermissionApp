using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermissionApp.DbItems
{
    public partial class UserModuleUicontrolsPermissions
    {
        public Guid Id { get; set; }
        [ForeignKey("ModuleUi")]
        public Guid ModuleUiid { get; set; }
        public string UserId { get; set; }
        [ForeignKey("ModuleUicontrols")]
        public Guid ControlId { get; set; }
        public bool IsPermitted { get; set; }
        public int PermissionType { get; set; }
        public bool IsActive { get; set; }
        public bool IsOpen { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public ModuleUicontrols ModuleUicontrols { get; set; }
        public ModuleUi ModuleUi { get; set; }
    }
}
