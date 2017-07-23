using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevOpsDashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsDashboard.Model.Tests
{
    [TestClass()]
    public class DashboardMessageGenericTests
    {
        [TestMethod()]
        public void DashboardMessageGenericTest_Payload()
        {

            string json = @"{'Message':'Message','Title':'Title'}";
            DashboardMessageGeneric msg = DashboardMessageGeneric.CreateFromJson(json);
            Assert.AreEqual(msg.Message, "Message");
            Assert.AreEqual(msg.Title, "Title");
            Assert.AreEqual(msg.Category, "Generic");
            Assert.AreEqual(msg.Context, "");
        }

        [TestMethod()]
        public void DashboardMessageGenericTest_Params()
        {
            DashboardMessageGeneric msg = new DashboardMessageGeneric("Title", "Message");
            Assert.AreEqual("Message",msg.Message );
            Assert.AreEqual("Title",msg.Title);
            Assert.AreEqual("Generic",msg.Category);
            Assert.AreEqual("",msg.Context);

        }
    }
}