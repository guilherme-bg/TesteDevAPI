using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDevBlipAPI.Models;
using TesteDevBlipAPI.Services;

namespace TesteDevBlipAPI.Controllers {
    public class RepositoriesController : ControllerBase {
        private readonly RepositoriesService _repositoriesService;
        public RepositoriesController(RepositoriesService repositoriesService) {
            _repositoriesService = repositoriesService;
        }


        [HttpGet]
        [Route("api/getrepositories")]
        public string GetRepositories() {
            return  _repositoriesService.RepositoriesFilter();
        }
    }
}
