using System.Collections.Generic;
using Nancy;

namespace NancyApp
{
    public class TestNancyModule : NancyModule
    {
        public static IList<string> Messages = new List<string>();

        public TestNancyModule() : base("/")
        {
            Post["/helloWorld"] = delegate { return StoreRequest("HelloWorld"); };
        }

        public System.Net.HttpStatusCode StoreRequest(string message)
        {
            Messages.Add(message);

            return System.Net.HttpStatusCode.OK;
        }
    }
}
