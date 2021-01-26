using NUnit.Framework;

namespace ApiTests
{
    public class Tests
    {

        //private MaterialService _materialService = new MaterialService(
        //    new ApplicationContext(new DbContextOptionsBuilder<ApplicationContext>()
        //        .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NewMaterialDb;Trusted_Connection=True;")
        //        .Options), new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json")
        //    .Build());
        //private DocsService docsService = DocsService();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}