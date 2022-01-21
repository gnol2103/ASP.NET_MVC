using System.Data;
using ASP.NET_MVC.Data;

namespace ASP.NET_MVC.Service
{
    public interface IMemberService
    {
        List<Member> GetMaleMember();
        string OldestMember();
        Tuple<List<Member>,List<Member>,List<Member>> GetMemberByYear(int year);
        List<Member> GetAllMember();
        DataTable Export();

        List<string> GetMemberFullName();
    }
}