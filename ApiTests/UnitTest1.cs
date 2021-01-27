using Api1.DocsServices.BLL;
using Api1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace ApiTests
{
    public class Tests
    { 
        private DocsService docsService = new DocsService(
            new DocContext (new DbContextOptionsBuilder<DocContext>().UseInMemoryDatabase("DocsList").Options), 
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build());

      

        [SetUp]
        public void Setup()
        {
            var doc = new Doc
            {
                Category = Category.APPLICATION,
                Name = "TestFile.txt",
            };

            var ver = new Api1.Models.Version
            {
                Doc = doc,
                Release = 1,
                Size = 1234,
                UploadDateTime = DateTime.Now,
                Path = @"C:\\Files\\Tests",
            };

            DocsService._context.Add(doc);// как обратиться к контексту, который создается в начале, in memory?
            dbContext.Versions.Add(ver);
            int res = dbContext.SaveChanges();
        }

        [Test]
        public void GetDocs_Get1Doc_NotNull()
        // [Тестируемый метод]_[Сценарий]_[Ожидаемое поведение].
        {

            List<Doc> result = DocsService.GetDocs();//почумц не позволяет обратиться к сервисам моим?

            Assert.NotNull(result);
        }
    }
}