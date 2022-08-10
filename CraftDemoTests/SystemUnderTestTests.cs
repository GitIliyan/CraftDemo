using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tests
{
    [TestClass()]
    public class SystemUnderTestTests
    {
        [TestMethod()]
        public async Task DoStuffAsyncTestAsync()
        {
            string gitUser = "GitIliyan";
            string gitCredentials = "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";
            string apiKey = "GT8cDCRNRu7hE5SKr7CX0";
            string fdDomain = "smile6541";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That((await SystemUnderTest.DoStuffAsync(gitUser, gitCredentials, apiKey, fdDomain)).ContentType, Is.EqualTo("application/json"));
        }
    }
}