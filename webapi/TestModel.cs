using System;
using LiteDB;
namespace webapi
{
    public class TestModel
    {
        public ObjectId Id{get;set;}
        public string Name{get;set;}
        public string[] Nicks{get;set;}
        public DateTime BirthDay{get;set;}
        public string UserId{get;set;}
        public string PassWord{get;set;}
    }
}