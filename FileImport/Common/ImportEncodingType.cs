using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileImport.Common
{
    public enum ImportEncodingType
    {
        Default = 1,
        ASCII = 2,
        UTF7 = 3,
        UTF8 = 4,
        UTF32 = 5,
        BigEndianUnicode = 6,
        Unicode = 7
    }
}
