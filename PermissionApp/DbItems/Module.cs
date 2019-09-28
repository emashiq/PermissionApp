using System;
using System.Collections.Generic;

namespace PermissionApp.DbItems
{
    public partial class Module
    {
        public Module()
        {
            ModuleUIs = new List<ModuleUi>();
        }
        public Guid Id { get; set; }
        public string ModuleName { get; set; }
        public bool IsActive { get; set; }
        public bool IsOpen { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public List<ModuleUi> ModuleUIs { get; set; }
    }
}
