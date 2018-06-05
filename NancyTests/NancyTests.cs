using System;
using System.Linq;
using Nancy.Hosting.Self;
using NUnit.Framework;
using System.Net.Http;
using NancyApp;

namespace NancyTests
{
    [TestFixture]
    public class NancyTests
    {
        NancyHost _server;

        [SetUp]
        public void SetUp()
        {
            _server = new NancyHost(new Uri("http://localhost:9000"));

            _server.Start();
        }

        [Test]
        public async void WeGetTheRightStatusCode()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri("http://localhost:9000/helloWorld"));

            await client.SendAsync(request);

            Assert.That(TestNancyModule.Messages.Count, Is.EqualTo(1));
            Assert.That(TestNancyModule.Messages.First(), Is.EqualTo("HelloWorld"));
        }
}
}
