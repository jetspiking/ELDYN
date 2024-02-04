using ELDYN.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ELDYN.Core
{
    public class DynamicEngine
    {
        private ELDYNArguments _eldynArguments;

        public DynamicEngine(ELDYNArguments eldynArguments)
        {
            _eldynArguments = eldynArguments;

            TemplateInstruction? templateInstruction = JsonManager.DeserializeFromFile<TemplateInstruction>(eldynArguments.JsonFilePath);
            if (templateInstruction == null)
            {
                UserWriter.WriteToUserAndCrash(AppStrings.InvalidJsonFile + eldynArguments.JsonFilePath + AppStrings.SuggestEldynManual);
                return;
            }

            String output = String.Empty;
            ProcessTemplate(templateInstruction, ref output);

            UserWriter.WriteToUser(AppStrings.NoticeEldynWriting);
            File.WriteAllText(eldynArguments.OutputFilePath, output);
        }

        public void ProcessTemplate(TemplateInstruction templateInstruction, ref String fileContent)
        {
            // Validate file extension.
            String templatePath = Path.Combine(_eldynArguments.TemplateDirectoryPath, (templateInstruction.Template + AppStrings.TemplateExtension));

            // Validate template.
            if (!File.Exists(templatePath))
            {
                UserWriter.WriteToUserAndCrash(AppStrings.TemplateFileMissing + templateInstruction.Template);
                return;
            }

            // Template exists, read template file into String.
            String templateContent = File.ReadAllText(templatePath);

            // Validate child templates. Validating child templates should be done prior to actively modifying templateContent (as done for the values), to prevent potential looping problems.
            if (templateInstruction.Children != null)
                foreach (TemplateInstruction childTemplateInstruction in templateInstruction.Children)
                    ProcessTemplate(childTemplateInstruction, ref templateContent);

            // Validate values for template.
            if (templateInstruction.Properties != null)
                foreach (TemplateValue templateValue in templateInstruction.Properties)
                {
                    String valueMatchPattern = $@"\$ELDYN:{templateValue.Id}";
                    templateContent = Regex.Replace(templateContent, valueMatchPattern, templateValue.Assign);
                }

            // Validate whether this is the root template for cleanup template commands purposes.
            if (fileContent != String.Empty)
            {
                String templateMatchPattern = $@"\$ELDYN::{templateInstruction.Template}";
                MatchCollection matches = Regex.Matches(fileContent, templateMatchPattern);
                for (Int32 i = matches.Count - 1; i > -1; i--)
                {
                    Match match = matches[i];
                    fileContent = fileContent.Insert(match.Index, $"{templateContent}\n");
                }
            }
            else
            {
                fileContent = templateContent;
                const String cleanPattern = $@"\n?\$ELDYN::([a-zA-Z0-9]+).*";
                MatchCollection matches = Regex.Matches(fileContent, cleanPattern);
                foreach (Match match in matches)
                    fileContent = Regex.Replace(fileContent, cleanPattern, String.Empty);
            }

            UserWriter.WriteToUser(AppStrings.TemplateProcessed + templateInstruction.Template);
        }
    }
}
