﻿using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Test.Authorization;
using Test.Users;
using Microsoft.AspNetCore.Mvc;

namespace Test.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : TestControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}