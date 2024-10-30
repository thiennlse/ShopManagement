using BusinessObject.Models;

namespace Repository.Interface
{
    public interface IMemberRepo
    {
        Member ExistUsername(string username);
        void Add(Member member);
        void Update(int id,Member member);
        Member GetById(int id);
        List<Member> GetAll();  
        void Delete(int id);
    }
}
