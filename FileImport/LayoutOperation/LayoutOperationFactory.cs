using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileImport.Interface;
using FileImport.Common;
using FileImport.Base;

namespace FileImport.LayoutOperation
{
    public abstract class LayoutOperationFactory
    {

        private ILayout _layout;
        
        public ImportFile File
        {
            get
            {
                return ((LayoutBase)this._layout).ImportFile;
            }
        }        

        public ILayout Layout
        {
            get { return _layout; }
        }

        public LayoutOperationFactory(LayoutType Type)
        {
            switch (Type)
            {
                case LayoutType.Amex: _layout = new LayoutSample.AmexLayout(); break;
                case LayoutType.Hipercard: _layout = new LayoutSample.HipercardLayout(); break; 
            }
        }

    }
}
