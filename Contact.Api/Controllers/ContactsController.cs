using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact.Api.ResponseModels;
using Contact.DatabaseManager.Contracts;
using Contact.DatabaseManager.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactManager _contactManager;
        public ContactsController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        [HttpGet]
        [Route("GetAllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            ApiResponse<List<ContactDto>> response = new ApiResponse<List<ContactDto>>()
            {
                Success = true,
                Data = null,
                ErrorMessage = ""
            };

            try
            {
                response.Data = await _contactManager.GetAllContacts();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                //TODO log errors here
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("AddNewContact")]
        public async Task<IActionResult> AddNewContact(ContactDto contactDto)
        {
            ApiResponse<bool> response = new ApiResponse<bool>()
            {
                Success = true,
                Data = false,
                ErrorMessage = ""
            };

            try
            {
                response.Data = await _contactManager.AddNewContact(contactDto);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                //TODO log errors here
            }

            return Ok(response);
        }


        [HttpPost]
        [Route("UpdateContact")]
        public async Task<IActionResult> UpdateContact(ContactDto contactDto)
        {
            ApiResponse<bool> response = new ApiResponse<bool>()
            {
                Success = true,
                Data = false,
                ErrorMessage = ""
            };

            try
            {
                response.Data = await _contactManager.UpdateContact(contactDto);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                //TODO log errors here
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>()
            {
                Success = true,
                Data = false,
                ErrorMessage = ""
            };

            try
            {
                response.Data = await _contactManager.DeleteContact(id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                //TODO log errors here
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetContactById/{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            ApiResponse<ContactDto> response = new ApiResponse<ContactDto>()
            {
                Success = true,
                Data = null,
                ErrorMessage = ""
            };

            try
            {
                response.Data = await _contactManager.GetConmtactById(id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                //TODO log errors here
            }

            return Ok(response);
        }
    }
}
