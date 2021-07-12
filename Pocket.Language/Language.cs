using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Pocket.Language
{
    public class Language
    {
        public bool clicked = false;
        public string language;
        public ResourceManager rm;
        private void ChangeLanguage()
        {
            
            if (clicked == true && language == "Shqip")
            {
                rm = new ResourceManager("Pocket.Languages.lang_al", Assembly.GetExecutingAssembly());
                ChangeWordsLanguage(rm);
                language = "English";
            }
            else
            {
                rm = new ResourceManager("Pocket.Languages.lang_en", Assembly.GetExecutingAssembly());
                ChangeWordsLanguage(rm);
                language = "Shqip";
            }
            clicked = false;
        }
    }
}
