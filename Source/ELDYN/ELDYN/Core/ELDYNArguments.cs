using ELDYN.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDYN.Core
{
    public class ELDYNArguments
    {
        public String JsonFilePath { get; set; }
        public String TemplateDirectoryPath { get; set; }
        public String OutputFilePath { get; set; }

        public ELDYNArguments(String jsonFilePath, String templateDirectoryPath, String outputFilePath)
        {
            JsonFilePath = jsonFilePath;
            TemplateDirectoryPath = templateDirectoryPath;
            OutputFilePath = outputFilePath;

            if (!File.Exists(jsonFilePath))
                UserWriter.WriteToUserAndCrash(AppStrings.InvalidJsonFilePath + $"\"{jsonFilePath}\"!");

            if (!Directory.Exists(templateDirectoryPath))
                UserWriter.WriteToUserAndCrash(AppStrings.InvalidTemplateDirectoryPath + $"\"{templateDirectoryPath}\"!");
        }
    }
}
