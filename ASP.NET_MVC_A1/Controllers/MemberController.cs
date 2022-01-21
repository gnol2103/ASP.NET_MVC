using Microsoft.AspNetCore.Mvc;
using ASP.NET_MVC.Service;
using System.Data;
using ClosedXML.Excel;

namespace ASP.NET_MVC.Controllers
{
    // [Route("[controller]")]
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IMemberService _memberService;

        public MemberController(ILogger<MemberController> logger,IMemberService memberService)
        {
            _logger = logger;
            _memberService=memberService;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        public IActionResult GetMaleMember(){
            return Ok(_memberService.GetMaleMember());
        }
        public IActionResult OldestMember(){
            return Ok(_memberService.OldestMember());
        }
        public IActionResult GetAllMember(){
            return Ok(_memberService.GetAllMember());
        }
        public IActionResult GetMemberFullName(){
            return Ok(_memberService.GetMemberFullName());
        }
        public IActionResult GetMemberByYear(int year){
            return Ok(_memberService.GetMemberByYear(year));
        }
        public FileResult ExportExcellFile(){
            DataTable table=_memberService.Export();
            using (XLWorkbook wb=new XLWorkbook()){

                wb.Worksheets.Add(table,"Member");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AllMember.xlsx");
                }
            }
        }
    }
}