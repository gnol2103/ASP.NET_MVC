using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_MVC.Models;

namespace ASP.NET_MVC.Data
{
    public static class MemberData
    {
        public static List<Member> Members=new List<Member>(){
            new Member("Pham", "Long", Gender.Male, "0944531628", "Nam Dinh", "2000/03/21", true),
            new Member("Tran", "Hung", Gender.Female, "0944531628", "Nam Dinh", "2002/03/21", false),
            new Member("Vu", "Long", Gender.Male, "0944531628", "Ninh Binh", "1999/03/21", true),
            new Member("Pham", "Hong", Gender.Other, "0944531628", "Ha Noi", "2004/03/21", false),
            new Member("Vu", "Lan", Gender.Male, "0944531628", "Nam Dinh", "2001/03/21", false),
            new Member("Tran", "Hang", Gender.Male, "0944531628", "DakLak", "1999/03/21", false)
        };
    }
}