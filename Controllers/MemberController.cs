using System.Linq;
using EntityTask.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EntityTask
{
    [ApiController]
    [Route("member")]
    public class MemberController : ControllerBase
    {
        public readonly ILogger<MemberController> _logger;
        public readonly MemberContext _context;

        public MemberController(ILogger<MemberController> logger, MemberContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();

            return Ok(member);
        }

        [HttpGet]
        public IActionResult GetMember()
        {
            var member = _context.Members;
            return Ok(member);
        }

        [HttpGet("{id}")]
        public IActionResult GetMemberById(int id)
        {
            var member = _context.Members.First(i => i.Id == id);
            return Ok(member);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateMember(int id)
        {
            var member = _context.Members.First(i => i.Id == id);
            member.FullName = "Na Dul Set";
            _context.SaveChanges();
            return Ok(member);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var member = _context.Members.First(i => i.Id == id);
            _context.Members.Remove(member);
            _context.SaveChanges();
            return Ok(member);
        }

    } 
}