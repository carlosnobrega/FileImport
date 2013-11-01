using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileImport.Common;
using FileImport.Base;

namespace FileImport.Interface
{
    public interface ILayout
    {
        //TODO: FEEL FREE TO CHANGE THE STRUCTURE AND THE METHOD SIGNATURE
        LayoutType LayoutType {get;}

        //Used to Import the rows following the defined file structure
        void Import(string fileName);

        //Used to validate the structure of the file
        void ValidateStructure();

        //Used to validate the data present on the file
        void Validate();

        //Used to save the data
        void Save();

        //You can add the database context and file ID, as parameters, 
        //to save after import or log the errors
    }
}