using System.Data;
using ASP.NET_MVC.Data;
using ASP.NET_MVC.Models;

namespace ASP.NET_MVC.Service
{
    public class MemberService : IMemberService
    {
        public List<Member> GetAllMember()
        {
            return MemberData.Members;
        }
        public List<String> GetMemberFullName()
        {
            List<String> MemberFullName=new List<String>();
            foreach(Member m in MemberData.Members){
                MemberFullName.Add(string.Format("{0} {1}",m.FirstName,m.LastName));
            }
            return MemberFullName;
        }
        public DataTable Export(){
            DataTable table= new DataTable();
            table.Columns.AddRange(new DataColumn[7]{
                new DataColumn("FirstName"),
                new DataColumn("LastName"),
                new DataColumn("Gender"),
                new DataColumn("DateOfBirth"),
                new DataColumn("BirthPlace"),
                new DataColumn("Phone"),
                new DataColumn("IsGraduated")});
            List<Member> members=GetAllMember();
            foreach(Member m in members){
                table.Rows.Add(m.FirstName, m.LastName, m.Gender.ToString(), m.DateOfBirth.ToShortDateString(),m.BirthPlace,m.PhoneNumber,m.IsGraduated?"yes":"No");
            }
            return table;
        }

        public Tuple<List<Member>, List<Member>, List<Member>> GetMemberByYear(int year)
        {
            var lessThan2000 = MemberData.Members.Where(x => x.DateOfBirth.Year < year).ToList();
            var greaterThan2000 = MemberData.Members.Where(x => x.DateOfBirth.Year > year).ToList();
            var bornIn2000 = MemberData.Members.Where(x => x.DateOfBirth.Year == year).ToList();
            return Tuple.Create(lessThan2000, greaterThan2000, bornIn2000);
        }

        public string OldestMember()
        {
            var OldestMember = MemberData.Members.FirstOrDefault(m => m.DateOfBirth.Year == MemberData.Members.Min(m => m.DateOfBirth.Year));
            return OldestMember?.MemberInfo;
        }

        public List<Member> GetMaleMember()
        {
            return MemberData.Members.Where(x => x.Gender==Gender.Male).ToList();
        }
    }
}