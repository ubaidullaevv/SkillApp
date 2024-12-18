using Infrastructore.Interfaces;
using Infrastructore.Response;
using Infrastructore.Context;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class SkillController(ISkillService SkillService):ControllerBase
{
 [HttpPost]
 public async Task<Response<bool>> Add(Skill Skill)
 {
    var response= await SkillService.AddSkill(Skill);
    return response;
 }
 [HttpGet]
 public async Task<Response<List<Skill>>> GetAll()
 {
    var response=await SkillService.GetSkills();
    return response;
 }
 [HttpPut]
 public async Task<Response<bool>> Update(Skill Skill)
 {
    var response= await SkillService.UpdateSkill(Skill);
    return response;
 }
 [HttpGet("get-by-id")]
 public async Task<Response<Skill>> GetById(int id)
 {
    var response= await SkillService.GetSkillById(id);
    return response;
 }
 [HttpDelete]
 public async Task<Response<bool>> Delete(int id)
 {
    var response=await SkillService.DeleteSkill(id);
    return response;
 }
}