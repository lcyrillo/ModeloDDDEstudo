using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModeloDDDEstudo.Domain.Entities;
using ModeloDDDEstudo.Service.Services;
using ModeloDDDEstudo.Service.Validator;

namespace ModeloDDDEstudo.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private BaseService<User> service = new BaseService<User>();

        public IActionResult Post([FromBody] User item)
        {
            try
            {
                service.Post<UsuarioValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Put([FromBody] User item)
        {
            try
            {
                service.Put<UsuarioValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete<UsuarioValidator>(item);

                return new NoContentResult();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.Get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}