using Octokit;
using Octokit.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GuildaRPG {
    class GithubAPI
    {
        //public static void Main(string[] args) => new GithubAPI().MainAsync().GetAwaiter().GetResult();

        static readonly string USER = "rafaeu749";
        static readonly string REPO = "guilda";

        static readonly InMemoryCredentialStore credentials = new InMemoryCredentialStore(new Credentials(Properties.Resources.GITHUB_TOKEN));
        static GitHubClient client = new GitHubClient(new ProductHeaderValue(USER), credentials);

        public async Task MainAsync()
        {
            try
            {
                RepositoryContent repositoryContent = await GetDataFile("update.json");

                if (repositoryContent != null)
                {
                    string newContent = "test " + DateTime.Now;   
                    await UpdateDataFile("update.json", repositoryContent.Sha, newContent);
                }

                Console.WriteLine("== DONE ==");
                Console.Read();
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                Console.Read();
                Environment.Exit(-1);
            }
        }

        public async Task<RepositoryContent> GetDataFile(string fileName)
        {
            IReadOnlyList<RepositoryContent> repositoryContentList = await client.Repository.Content.GetAllContents(USER, REPO, "docs/data/" + fileName);

            if (repositoryContentList.Count > 0)
            {
                return repositoryContentList[0];
            }

            throw new System.IO.FileNotFoundException(String.Format("File [{0}] not found!", fileName));
        }

        public async Task UpdateDataFile(string fileName, string sha, string newContent)
        {
            await client.Repository.Content.UpdateFile(USER, REPO, "docs/data/" + fileName,
                new UpdateFileRequest("Update " + fileName, newContent, sha, "master"));
        }
    }
}
