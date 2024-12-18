using Infrastructore.Response;
using Infrastructore.Context;
using Domain.Models;
namespace Infrastructore.Interfaces;

public interface ISkillService
{
    public Task<Response<List<Skill>>> GetSkills();
    public Task<Response<bool>> AddSkill(Skill skill);
    public Task<Response<bool>> UpdateSkill(Skill skill);
    public Task<Response<bool>> DeleteSkill(int id);
    public Task<Response<Skill>> GetSkillById(int id);
}