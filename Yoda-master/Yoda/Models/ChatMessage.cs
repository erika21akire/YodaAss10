using Azure.AI.OpenAI;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoda.Enums;

namespace Yoda.Models
{
    public class BobsChatMessage
    {
        public ChatMessageTypeEnum MessageType { get; set; }
        public string? MessageBody { get; set; }

        public static implicit operator BobsChatMessage(Response<ChatCompletions> v)
        {
            throw new NotImplementedException();
        }
    }
}
