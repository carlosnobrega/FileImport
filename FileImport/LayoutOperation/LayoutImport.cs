using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FileImport.Common;
using FileImport.Base;

namespace FileImport.LayoutOperation
{
    public sealed class LayoutImport : LayoutOperationFactory
    {

        private LayoutBase _layoutBase;
        public LayoutBase LayoutBase { get { return _layoutBase; } }

        private BreakPoint _breakPoint;
        public BreakPoint BreakPoint { get { return _breakPoint; } }

        public LayoutImport(string FilePath, bool ImportOnlyFirstLine, LayoutType LayoutType) : base(LayoutType)
        {
            _layoutBase = (LayoutBase)Layout;
        
            _layoutBase.ImportOnlyFirstLine = ImportOnlyFirstLine;

            _breakPoint = BreakPoint.Success;

            Layout.Import(FilePath);

            if(_layoutBase.HasError)
            {
                _breakPoint = BreakPoint.Import;
                return;    
            }

            //TODO: FEEL FREE TO CHANGE THE STRUCTURE AND THE METHOD SIGNATURE
            if(!ImportOnlyFirstLine)
            {
                Layout.ValidateStructure(_layoutBase.Attributes);
                if (_layoutBase.HasError)
                {
                    _breakPoint = BreakPoint.ValidateStructure;
                    return;  
                }

                Layout.Validate(_layoutBase.Attributes);
                if (_layoutBase.HasError)
                {
                    _breakPoint = BreakPoint.Validate;
                    return;  
                }

                Layout.Save();
                if (_layoutBase.HasError)
                {
                    _breakPoint = BreakPoint.Save;
                    return;  
                }

            }            

        }
        
    }
}


