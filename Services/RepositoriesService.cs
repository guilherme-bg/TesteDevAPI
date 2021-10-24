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

        public async Task<List<Repositories>> GetAllRepositoriesAsync() {
            try {

                List<Repositories> repoCollection = null;

                using (var client = new HttpClient()) {
                    client.BaseAddress = new Uri(Constants.urlApiGit);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.mediaType));
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(Constants.produtctName, Constants.produtctVersion));

                    var response = await client.GetAsync(Constants.reposAddress);

                    if (response.IsSuccessStatusCode) {
                        var data = response.Content.ReadAsStringAsync();
                        repoCollection = JsonConvert.DeserializeObject<List<Repositories>>(data.Result);
                    }
                }

                return repoCollection;

            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public string RepositoriesFilteredByLanguage(string language, int quantity) {
            try {
                var filteredRepositories = GetAllRepositoriesAsync().Result.FindAll(x => x.Language == language).OrderBy(x => x.Created_At).ToList();

                List<Repositories> repos = new List<Repositories>();

                for (int i = 0; i < quantity; i++) {
                    repos.Add(filteredRepositories[i]);
                }

                string jsonRepos;

                using (var webClient = new WebClient()) {
                    jsonRepos = JsonConvert.SerializeObject(repos);
                }

                return jsonRepos;

            } catch (Exception e) {
                throw new Exception(e.Message);
            }

        }
    }
}
