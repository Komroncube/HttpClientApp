using Market.Service.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HttpCRUD
{
    public class HttpCrudMethod
    {
        string url = "https://localhost:7153/api/Products/Categories";
        
        
        public async Task<string> GetAllAsync()
        {
            string json;
            using (HttpClient client = new HttpClient())
            {
                json = await client.GetAsync(url).Result.Content.ReadAsStringAsync();

            }
            return json;
        }
        public async Task<string> GetByIdAsync(int id)
        {
            string query = string.Format("https://localhost:7153/api/Products/Categories/{0}", id);
            string json;
            using (HttpClient client = new HttpClient())
            {
                json = await client.GetAsync(query).Result.Content.ReadAsStringAsync();
            }
            return json;
        }
        public async Task<string> PostAsync()
        {
            ProductForCreationDto product = new ProductForCreationDto()
            {
                Name = "Ruchka",
                Price = 132,
                CategoryId = 1,

            };
            string response;
            var json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using(HttpClient client = new HttpClient())
            {
                response = await client.PostAsync(url, data).Result.Content.ReadAsStringAsync();
            }
            return response;
        }
        public async Task<string> DeleteAsync(int id)
        {
            string response="";
            using(HttpClient client = new HttpClient())
            {

                string query = string.Format("https://localhost:7153/api/Products/Categories/{0}", id);
                var res = await client.DeleteAsync(query);
            }
            return response;
        }
        public async Task<string> PutAsync(int id)
        {
            ProductForCreationDto product = new ProductForCreationDto()
            {
                Name = "Ruchka",
                Price = 132,
                CategoryId = 1,

            };
            var json = JsonConvert.SerializeObject(product, Formatting.Indented);
            string response = "";
            string query = string.Format("https://localhost:7153/api/Products/Categories/{0}", id);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            using (HttpClient client = new HttpClient())
            {
                response = await client.PutAsync(query, data).Result.Content.ReadAsStringAsync();
            }
            return response;
           
        }
    }
}
