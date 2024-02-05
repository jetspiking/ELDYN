using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDYN.Misc
{
    public static class AppStrings
    {
        public static readonly String AppTitle = "ELDYN.exe";

        public static readonly String TemplateExtension = ".eldyn";
        public static readonly String TemplateFileMissing = "\nTemplate file not found: ";
        public static readonly String TemplateProcessed = "Processed template: ";

        public static readonly String SuggestArguments = "\nExpected \"ELDYN <path to JSON file> <path to template directory> <path to output file>\".\nE.g.: ELDYN \"C:\\ELDYN\\Certificate.json\" \"C:\\ELDYN\\Temp\" \"C:\\ELDYN\\Out\\Certificate.tex\"";
        public static readonly String SuggestEldynManual = "\nInfo on https://eldyn.nl";

        public static readonly String NoticeEldynStart = "\n========== STARTING ELDYN ==========";
        public static readonly String NoticeEldynStop = "========== STOPPING ELDYN ==========\n";
        public static readonly String NoticeEldynWriting = "------ Writing to output file ------";

        public static readonly String InvalidArguments = "\nThe arguments are not valid.";
        public static readonly String InvalidJsonFilePath = "\nInvalid path to JSON file: ";
        public static readonly String InvalidTemplateDirectoryPath = "\nTemplate directory does not exist: ";
        public static readonly String InvalidOutputFilePath = "\nOutput directory does not exist: ";
        public static readonly String InvalidJsonFile = "\nInvalid JSON file: ";

        public static readonly String HelpCommand = "help";
    }
}
