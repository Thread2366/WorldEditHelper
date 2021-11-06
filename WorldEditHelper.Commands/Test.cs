using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldEditHelper.Commands
{
    class Test
    {
        public static void X()
        {
            IMineCommand command = null;

            using (var choice = command.GetTokenChoice())
            {
                var token = choice.Options.FirstOrDefault(t => t.Description == "Some description");
                choice.Selected = token;
            }
        }
    }
}
