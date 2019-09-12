using Octokit;
using Octokit.Internal;
using System;
using System.Threading.Tasks;

namespace GuildaRPG {
    class GithubAPI
    {
        //public static void Main(string[] args) => new GithubAPI().MainAsync().GetAwaiter().GetResult();

        static readonly string USER = "rafaeu749";
        static readonly string REPO = "guilda";

        static readonly InMemoryCredentialStore credentials = new InMemoryCredentialStore(new Credentials("74240aee14512f957a25c7c1d48ac0d648cf0489"));
        static GitHubClient client = new GitHubClient(new ProductHeaderValue(USER), credentials);

        public async Task MainAsync()
        {
            try
            {

                await client.Repository.Commit.GetAll(USER, REPO).ContinueWith(async list =>
                {
                    foreach (GitHubCommit ghc in list.Result)
                    {
                        GitHubCommit full = await client.Repository.Commit.Get(USER, REPO, ghc.Sha);

                        Console.WriteLine(ghc.Commit.Message);
                        foreach (GitHubCommitFile file in full.Files)
                        {
                            Console.WriteLine("\t" + file.Filename);
                        }
                    }
                });

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
    }
}
