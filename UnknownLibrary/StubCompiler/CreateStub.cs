﻿using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace UnknownLibrary.Stub
{
    public static class CreateStub
    {
        public static CompilerResults CompileStub(string Hide, string[] LinesOfCode, string Output, string icoLocation, params string[] References)
        {
            var parameters = new CompilerParameters(References, Output);
            if (string.IsNullOrEmpty(icoLocation) != true)
            {
                parameters.CompilerOptions = @"/win32icon:" + icoLocation;
            }
            parameters.GenerateExecutable = true;
            if (Hide == "true")
            {
                parameters.CompilerOptions = "/target:winexe";
            }
            using (var provider = new CSharpCodeProvider()) 
            {
                return provider.CompileAssemblyFromSource(parameters, LinesOfCode);
            }
        }
    }
}
