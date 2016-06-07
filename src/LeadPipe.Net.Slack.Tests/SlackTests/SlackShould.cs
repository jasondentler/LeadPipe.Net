// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Slack.Tests.SlackTests
{
    /// <summary>
    /// Slack tests.
    /// </summary>
    [TestFixture]
    public class SlackShould
    {
        /// <summary>
        /// Test to make sure that an action is invoked AND exception is thrown when an assertion fails.
        /// </summary>
        [Test]
        public void InvokeActionAndThrowExceptionGivenAssertionFails()
        {
            // Arrange
            const string TestMessageText = "This is an example";

            var ioc = new InversionOfControl();
            ioc.Register<ISlackConfiguration, SlackConfiguration>();

            var slack = new Slack(ioc.Resolve<ISlackConfiguration>());

            // Act
            var message = slack.Build.Message(TestMessageText).GetMessage();

            // Assert
            Assert.That(message.Text.Equals(TestMessageText));
        }
    }
}