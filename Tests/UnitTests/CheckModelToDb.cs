// Copyright (c) 2018 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Data.Entity;
using DataLayer.EfCode;
using Ef6SchemaCompare;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.AssertExtensions;

namespace Tests.UnitTests
{
    public class CheckModelToDb
    {
        private readonly ITestOutputHelper _output;

        public CheckModelToDb(ITestOutputHelper output)
        {
            _output = output;
        }

        /// <summary>
        /// This checks the EF model against the Test SQL database.
        /// The error messages are EF-friendly, but the test is not comprehensive
        /// </summary>
        [Fact]
        public void CompareEfSqlTestOandGWebDbOk()
        {
            //SETUP  
            Database.SetInitializer<EfCoreContext>(null);   //You cannot set a null initialiser as Effort doesn't handle it.
            const string dbConfigRef = "BookAppDb";
            using (var db = new EfCoreContext(dbConfigRef))
            {
                var comparer = new CompareEfSql();

                //EXECUTE
                var status = comparer.CompareEfWithDb<EfCoreContext>(db);

                //VERIFY
                status.ShouldBeValid();
                _output.WriteLine(string.Join("\n", status.Warnings));
                status.HasWarnings.ShouldBeFalse("There were warnings.");
            }
        }
    }
}