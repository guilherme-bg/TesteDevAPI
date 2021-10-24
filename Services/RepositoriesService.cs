using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TesteDevBlipAPI.Models;

namespace TesteDevBlipAPI.Services {
    public class RepositoriesService {

        public async Task<List<Repositories>> GetRepositoriesAsync() {

            List<Repositories> repoCollection = null;

            var token = "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";
            
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("TesteDevBlipAPI", "1"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);

                var response = await client.GetAsync("users/takenet/repos?per_page=100&language=c%23");

                if (response.IsSuccessStatusCode) {
                    var data = response.Content.ReadAsStringAsync();
                    repoCollection = JsonConvert.DeserializeObject<List<Repositories>>(data.Result);
                }
            }
            
            //var url = "https://api.github.com/users/takenet/repos";

            //using (var webClient = new WebClient()) {                
            //    var rawJSON = webClient.DownloadString(url);
            //    repoCollection = JsonConvert.DeserializeObject<List<Repositories>>(rawJSON);
            //}        


            return repoCollection;
        }

        public string RepositoriesFilter() {
            
            var filteredRepositories = GetRepositoriesAsync().Result.FindAll(x => x.Language == "C#").OrderBy(x => x.Created_At).ToList();


            List<Repositories> repos = new List<Repositories>();

            for (int i = 0; i < 5; i++) {
                repos.Add(filteredRepositories[i]);
            }

            string jsonRepos;

            using (var webClient = new WebClient()) {
                jsonRepos = JsonConvert.SerializeObject(repos);
            }           

            return jsonRepos;
        }
    }
}
