using ELDYN.Core;
using ELDYN.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDYN.Startup
{
    public static class StartupParser
    {
        public static ELDYNArguments Parse(String[] args) 
        {
            if (args.Length == 1 && args[0].ToLower() == AppStrings.HelpCommand)
                UserWriter.WriteToUserAndCrash(AppStrings.SuggestArguments + AppStrings.SuggestEldynManual);
            else if (args.Length != 3)
                UserWriter.WriteToUserAndCrash(AppStrings.InvalidArguments+AppStrings.SuggestArguments+AppStrings.SuggestEldynManual);

            return new ELDYNArguments(args[0], args[1], args[2]);
        }
    }
}
