﻿using System.Collections.Generic;
using System.IO;
using BExIS.DCM.Transform.Validation.DSValidation;
using BExIS.DCM.Transform.Validation.Exceptions;
using BExIS.Dlm.Entities.Data;


namespace BExIS.DCM.Transform.Input
{
    public interface IDataReader
    {


        FileStream Open(string fileName);

        DataTuple ReadRow(List<string> row, int indexOfRow);

        List<Error> ValidateRow(List<string> row, int indexOfRow);
        
        List<Error> ValidateComparisonWithDatatsructure(List<VariableIdentifier> row);

        /*
        ValueValidationManager CreateValueValidationManager(string varName, string dataType, bool optional, Variable variable);

        StructuredDataVariableUsage GetVariableUsage(VariableIdentifier hv);

        List<VariableIdentifier> GetDatastructureVariableIdentifiers();

        List<VariableIdentifier> GetDatastructureAsListOfVariableIdentifers(ICollection<StructuredDataVariableUsage> VariableUsageCollection);*/
    }
}
