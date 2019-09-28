using System;
using System.Collections.Generic;

namespace PermissionApp.DbItems
{
    public partial class ModuleUicontrols
    {
        public Guid Id { get; set; }
        public Guid ModuleUiid { get; set; }
        public string ControlName { get; set; }
        public bool IsActive { get; set; }
        public bool IsOpen { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
