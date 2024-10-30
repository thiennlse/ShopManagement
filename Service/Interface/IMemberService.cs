using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IMemberService
    {
        Member ExistUsername(string username);
        void Add(Member member);
        void Update(int id, Member member);
        Member GetById(int id);
        List<Member> GetAll();
        void Delete(int id);
    }
}
