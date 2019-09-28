using System;
using System.Collections.Generic;

namespace PermissionApp.DbItems
{
    public partial class ModuleUi
    {
        public ModuleUi()
        {
            ModuleUicontrols = new List<ModuleUicontrols>();
        }
        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }
        public string Uiname { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public bool IsOpen { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public List<ModuleUicontrols> ModuleUicontrols { get; set; }
    }
}
