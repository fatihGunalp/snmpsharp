﻿/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2010/12/11
 * Time: 11:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Lextm.SharpSnmpLib;
using Samples.Objects;
using Samples.Pipeline;
using Xunit;

namespace Samples.Unit.Objects
{
    public class SysORLastChangeTestFixture
    {
        [Fact]
        public void Test()
        {
            var sys = new SysORLastChange();
            Assert.Equal(new TimeTicks(0), sys.Data);
            Assert.Throws<AccessFailureException>(() => sys.Data = OctetString.Empty);
        }
    }
}
