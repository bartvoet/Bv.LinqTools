using System;
using Xunit;
using Bv.Tools.Tables;
using System.Collections.Generic;

namespace Bv.Tools.Tests
{
    public class SimpleTableMapperTest
    {

        [Fact]
        public void Constructor_ThrowsException_WhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new SimpleTableMapper<string>(null)
           );
        }

        private static List<string> DUMMY_ENUMERABLE = new List<string>();
        private static Func<string,string> DUMMY_MAPPER = (x) => x;

        [Fact]
        public void WriteTo_ThrowsException_WhenTableSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new SimpleTableMapper<string>(DUMMY_ENUMERABLE).WriteTo(null)
            );
        }

        [Fact]
        public void Field_ThrowsException_WhenMapperIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new SimpleTableMapper<string>(DUMMY_ENUMERABLE).Field("aa", null)
            );
        }
    }
}
