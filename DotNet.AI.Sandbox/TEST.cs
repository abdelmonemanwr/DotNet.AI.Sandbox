using Microsoft.Extensions.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.AI.Sandbox
{
    internal class TEST
    {
        private readonly IChatClient chatClient;

        public TEST(IChatClient chatClient)
        {
            this.chatClient = chatClient;
        }

        public async Task TellMeJoke()
        {
            var chatCompletion = await chatClient.GetResponseAsync("TELL ME FUNNY JOKE");

            Console.WriteLine(chatCompletion.Message.Text);
        }
    }
}
