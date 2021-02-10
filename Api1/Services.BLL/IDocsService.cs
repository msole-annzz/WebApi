using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Models;
using Api1.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Api1.DocsServices.BLL
{
    public interface IDocsService
    {
        Task UploadFileAsync(FileResource formFile);
        IList<Doc> GetDocs(Category? category);
        IList<Doc> GetDoc(string name);
        Task<byte[]> DownloadDocAsync(string name, int category, int? release);
        Doc ChangeCategory(string name, Category oldCategory, Category newCategory);
        Doc DeleteDoc(string name, Category category);
    }
}