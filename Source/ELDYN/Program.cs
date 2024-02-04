using ELDYN.Core;
using ELDYN.Misc;
using ELDYN.Startup;

namespace ELDYN
{
    internal class Program
    {
        static void Main(String[] args)
        {
            UserWriter.WriteToUser(AppStrings.NoticeEldynStart);
            ELDYNArguments startupArguments = StartupParser.Parse(args);
            DynamicEngine dynamicEngine = new(startupArguments);
            UserWriter.WriteToUser(AppStrings.NoticeEldynStop);

            Environment.Exit(0);
        }
    }
}
