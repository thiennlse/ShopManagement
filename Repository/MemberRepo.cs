using BusinessObject.Models;
using Repository.Interface;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class MemberRepo : IMemberRepo
    {
        private readonly ShopManagementDbContext _context;
        private  static MemberRepo _instance;

        public MemberRepo()
        {
            _context = new ShopManagementDbContext();
        }

        public static MemberRepo Instance 
        {
            get {
                if(_instance == null)
                {
                    _instance = new MemberRepo();
                }
                return _instance; 
            } 
        }
        public void Add(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var member = GetById(id);
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        public Member ExistUsername(string username)
        {
            return _context.Members.FirstOrDefault(m => m.UserName.Equals(username));
        }

        public List<Member> GetAll()
        {
            return _context.Members.ToList();   
        }

        public Member GetById(int id)
        {
            return _context.Members.FirstOrDefault(m => m.Id.Equals(id));
        }

        public void Update(int id, Member member)
        {
            member.Id = id;
            _context.Entry(member).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
