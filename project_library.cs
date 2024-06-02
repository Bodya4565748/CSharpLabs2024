using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    class Program
    {
        static string baseUrl = "https://to-do2-46294-default-rtdb.europe-west1.firebasedatabase.app/projects";

        static async Task Main(string[] args)
        {
            await FetchProjects();
            while (true)
            {
                Console.WriteLine("\n1. Add Project");
                Console.WriteLine("2. Delete Project");
                Console.WriteLine("3. Update Project");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await AddProject();
                        break;
                    case "2":
                        await DeleteProject();
                        break;
                    case "3":
                        await UpdateProject();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static async Task FetchProjects()
        {
            try
            {
                Console.WriteLine("Fetching projects...");
                string result = await GetRequest(baseUrl + ".json");
                Console.WriteLine("Projects fetched successfully.");
                // Обробка результатів запиту
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch projects. Error: {ex.Message}");
            }
        }

        static async Task AddProject()
        {
            try
            {
                Console.Write("Enter project name: ");
                string projectName = Console.ReadLine();
                Project newProject = new Project { Name = projectName, Completed = false };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(newProject);
                await PostRequest(baseUrl + ".json", json);
                Console.WriteLine("Project added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add project. Error: {ex.Message}");
            }
        }

        static async Task DeleteProject()
        {
            try
            {
                Console.Write("Enter project id to delete: ");
                string projectId = Console.ReadLine();
                await DeleteRequest($"{baseUrl}/{projectId}.json");
                Console.WriteLine("Project deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete project. Error: {ex.Message}");
            }
        }

        static async Task UpdateProject()
        {
            try
            {
                Console.Write("Enter project id to update: ");
                string projectId = Console.ReadLine();
                Console.Write("Enter updated project name: ");
                string projectName = Console.ReadLine();
                Console.Write("Enter updated completion status (true/false): ");
                bool completed = Convert.ToBoolean(Console.ReadLine());
                Project updatedProject = new Project { Name = projectName, Completed = completed };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(updatedProject);
                await PatchRequest($"{baseUrl}/{projectId}.json", json);
                Console.WriteLine("Project updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update project. Error: {ex.Message}");
            }
        }

        static async Task<string> GetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    return await reader.ReadToEndAsync();
                }
            }
        }

        static async Task PostRequest(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (StreamWriter writer = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                await writer.WriteAsync(data);
            }

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                // Можливо, тут є обробка відповіді
            }
        }

        static async Task DeleteRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                // Можливо, тут є обробка відповіді
            }
        }

        static async Task PatchRequest(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "PATCH";
            request.ContentType = "application/json";

            using (StreamWriter writer = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                await writer.WriteAsync(data);
            }

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                // Можливо, тут є обробка відповіді
            }
        }
    }

    class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}
