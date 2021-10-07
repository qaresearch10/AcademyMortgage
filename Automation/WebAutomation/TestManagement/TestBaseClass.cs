using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutomation.Utilities;

namespace WebAutomation.TestManagement
{
    [TestFixture]
    public class TestBaseClass
    {
        #region Fields
        public static readonly string ClientUrl = "";
        #endregion    

		[SetUp]
		public virtual void SetupBase()
		{
			SeleniumUtils.SetNewDriver();		
		}

		/// <summary>
		/// Invokes base teardown logic AND removes the selenium driver.  Don't call directly from overrides if further action requires use of the selenium driver...use DoBaseTeardown() instead and explicitly remove the selenium driver where appropriate in the derived class.
		/// </summary>
		[TearDown]
		public virtual void TearDownBase()
		{
			try
			{
				SeleniumUtils.driver.Quit();
				SeleniumUtils.driver?.Dispose();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			finally
			{
				SeleniumUtils.driver = null;
			}
		}
	}
}
