using System.Threading.Tasks;

using FluentAssertions;

#if NETCOREAPP2_1
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
#endif

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aliencube.AzureMessaging.SchemaValidation.ServiceBus.Tests
{
#if NETCOREAPP2_1
    [TestClass]
    public class ISchemaValidatorPluginTests
    {
        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Properties()
        {
            typeof(ISchemaValidatorPlugin)
                .Should().HaveProperty<string>("Name")
                    .Which.Should().BeReadable()
                          .And.NotBeWritable();

            typeof(ISchemaValidatorPlugin)
                .Should().HaveProperty<bool>("ShouldContinueOnException")
                    .Which.Should().BeReadable()
                          .And.NotBeWritable();

            typeof(ISchemaValidatorPlugin)
                .Should().HaveProperty<ISchemaValidator>("Validator")
                    .Which.Should().BeReadable()
                          .And.NotBeWritable();

            typeof(ISchemaValidatorPlugin)
                .Should().HaveProperty<string>("SchemaPathUserPropertyKey")
                    .Which.Should().BeReadable()
                          .And.NotBeWritable();
        }

        [TestMethod]
        public void Given_Type_Then_It_Should_Have_Methods()
        {
            typeof(ISchemaValidatorPlugin)
                .Should().HaveMethod("WithValidator", new[] { typeof(ISchemaValidator) })
                    .Which.Should().Return<ServiceBusPlugin>();

            typeof(ISchemaValidatorPlugin)
                .Should().HaveMethod("WithSchemaPathUserPropertyKey", new[] { typeof(string) })
                    .Which.Should().Return<ServiceBusPlugin>();

            typeof(ISchemaValidatorPlugin)
                .Should().HaveMethod("BeforeMessageSend", new[] { typeof(Message) })
                    .Which.Should().Return<Task<Message>>();

            typeof(ISchemaValidatorPlugin)
                .Should().HaveMethod("AfterMessageReceive", new[] { typeof(Message) })
                    .Which.Should().Return<Task<Message>>();
        }
    }
#endif
}
