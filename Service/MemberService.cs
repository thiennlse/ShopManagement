using BusinessObject.Models;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepo _repo;
        public void Add(Member member)
        {
            MemberRepo.Instance.Add(member);
        }

        public void Delete(int id)
        {
            MemberRepo.Instance.Delete(id);
        }

        public Member ExistUsername(string username)
        {
            return MemberRepo.Instance.ExistUsername(username);
        }

        public List<Member> GetAll()
        {
            return MemberRepo.Instance.GetAll();
        }

        public Member GetById(int id)
        {
            return MemberRepo.Instance.GetById(id);
        }

        public void Update(int id, Member member)
        {
            MemberRepo.Instance.Update(id, member);
        }
    }
}
