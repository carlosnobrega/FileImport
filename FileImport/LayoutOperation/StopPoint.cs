using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileImport.LayoutOperation
{
    public enum BreakPoint
    {
        Success = 0,
        Import = 1,
        ValidateStructure = 2,
        Validate = 3,
        Save = 4
    }
}
