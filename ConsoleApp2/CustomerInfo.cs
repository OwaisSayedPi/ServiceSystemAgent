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
    public class CustomerInfo : Page
    {
        OutResponse<List<User>> outResponse = new OutResponse<List<User>>();
        public CustomerInfo()
        {
            PageName = "Get Customer Information";
        }
        public override void DisplayQuestions()
        {
            Console.WriteLine("Enter Token");
            string Token = GetReader.GetString("Enter Currect Token");

            using (HttpClient client = new HttpClient())
            {
                outResponse = client.GetFromJsonAsync<OutResponse<List<User>>>($"https://localhost:44391/Api/Agent?token={Token}").Result;
            }

            Console.WriteLine("Customer Information ");
            foreach (var item in outResponse.ResData)
            {
                Console.WriteLine(String.Format("CustomerID: {0,-10}", item.UserID));
                Console.WriteLine(String.Format("BranchID: {0,-10}", item.Token));
                Console.WriteLine(String.Format("Service Type: {0,-10}", item.ServiceID));
                Console.WriteLine(String.Format("CounterID: {0,-10}", item.CounterID));
                Console.WriteLine(String.Format("Status: {0,-10}", item.Status));
                Console.WriteLine(String.Format("Answers: {0,-10}", item.ResolvedTime));
            }
            Console.ReadLine();
        }
    }
}
