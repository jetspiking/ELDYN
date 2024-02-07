using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDYN.Core
{
    public class TemplateInstruction
    {
        public String Template;
        public TemplateValue[]? Properties;
        public TemplateInstruction[]? Children;

        public TemplateInstruction(String template, TemplateValue[]? properties, TemplateInstruction[]? children)
        {
            Template = template;
            Properties = properties;
            Children = children;
        }
    }

    public class TemplateValue
    {
        public String Id;
        public String Assign;

        public TemplateValue(String id, String assign)
        {
            Id = id;
            Assign = assign;
        }
    }
}
