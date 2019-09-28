using System;
using System.Collections.Generic;

namespace PermissionApp.DbItems
{
    public partial class PermissionType
    {
        public int Id { get; set; }
        public string PermissionTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
