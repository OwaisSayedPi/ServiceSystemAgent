using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ChangeStatus: Page
    {
        public ChangeStatus()
        {
            PageName = "Change Status";
        }
        OutResponse<string> outResponse = new OutResponse<string>();
        User user = new User();

        public override void DisplayQuestions()
        {
            Console.WriteLine("Enter Token");
            user.Token = GetReader.GetString("Enter Currect Token");
            Console.WriteLine("Change Status To:");
            Console.WriteLine("Waiting = 1,\nActive = 2,\nResolved = 3");
            user.Status = (StatusTypes)int.Parse(Console.ReadLine());

            using (HttpClient client = new HttpClient())
            {
                outResponse = client.PutAsJsonAsync($"https://localhost:44391/Api/Status?token={user.Token}&status={user.Status}",0).Result.Content.ReadFromJsonAsync<OutResponse<string>>().Result;
            }

            Console.WriteLine($"{outResponse.ResData}");
            Console.ReadLine();
        }
    }
}
