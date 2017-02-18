using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCodSeafood.Models;
using SonOfCodSeafood.Controllers;
using Xunit;



namespace SonOfCodSeafoodTests.cs.ModelTests
{
    public class EmailDbTest
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [Fact]
       public void Get_EmailFromDB_True()
        {
            string email = "test@gmail.com";
            EmailListMember listMember = new EmailListMember(email);

            db.EmailList.Add(listMember);
            db.SaveChanges();

            EmailListMember foundMember = db.EmailList.FirstOrDefault(e => e.EmailId == listMember.EmailId);

            Assert.Equal(foundMember, listMember);
        }

    }
}
