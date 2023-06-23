using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;

namespace ConsoleApp2
{
    public class Page
    {

        public static List<Page> pages = new List<Page>();
        public string PageName { get; set; }
        public Page()
        {
            PageName = "Main Menu";
        }
        Agent agent = new Agent();
        public virtual void DisplayMenu()
        {
            Login();
        }
        public virtual void DisplayOptions()
        {
            Console.WriteLine("Please Enter Your Choice :");

            foreach (var item in pages)
            {
                Console.WriteLine(pages.IndexOf(item) + 1 + " -- " + item.PageName);
            }

            int choice = GetReader.GetInteger("Enter Correct Choice");

            if (choice > pages.Count)
            {
                Console.Clear();
                this.DisplayOptions();
            }
            Console.Clear();
            pages[choice - 1].DisplayQuestions();
            //DisplayQuestions(serviceList.ElementAt(choice).ServiceID, BranchID);
            Console.Clear();
            this.DisplayOptions();
        }
        public virtual void DisplayQuestions() {}

        private void Login()
        {
            Console.WriteLine("Enter UserName:");
            agent.UserName = GetReader.GetString("Incorrect UserName, Please Enter Again.");

            Console.WriteLine("Enter Password:");
            agent.Password = GetReader.GetString("Incorrect Password, Please Enter Again.");

            if (!CheckConstraint(agent))
            {
                Login();
            }
            else
            {
                DisplayOptions();
            }
        }

        private bool CheckConstraint(Agent agent)
        {
            OutResponse<bool> check;
            using (HttpClient client = new HttpClient())
            {
                check = client.PostAsJsonAsync($"https://localhost:44391/api/Agent/", agent).Result.Content.ReadFromJsonAsync<OutResponse<bool>>().Result;
            }
            return check.ResData;
        }
    }
}