using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            try {
                return _repositoriesService.RepositoriesFilteredByLanguage(Constants.language, Constants.repositoriesQuantity);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}
