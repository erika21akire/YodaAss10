using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoda.Config
{
    public class ConstantSettings : ISettings
    {
        public string AzureOpenAiEndPoint { get => "https://starwarsyodaai.openai.azure.com/"; }
        
        public string AzureOpenAiKey { get => "618b82795d544ade8270c33a339dcedc"; }
    }
}
