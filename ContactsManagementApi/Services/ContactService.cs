using ContactsManagementApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ContactsManagementApi.Services
{
    public class ContactService
    {
        private readonly string _filePath = "C:\\Users\\anshu\\ContactsManagementApi\\data.json";

        public List<Contact> ReadData()
        {
            //if (!File.Exists(_filePath))
            //{
            //    return new List<Contact>(); // Return an empty list if file doesn't exist
            //}

            //var jsonData = File.ReadAllText(_filePath);
            //if (string.IsNullOrEmpty(jsonData))
            //{
            //    return new List<Contact>(); // Return an empty list if file is empty
            //}

            //var users = JsonSerializer.Deserialize<List<Contact>>(jsonData);
            //return users ?? new List<Contact>(); // Ensure users is not null


            if (!File.Exists(_filePath))
            {
                return new List<Contact>();
            }
            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Contact>>(jsonData);
        }

        public void WriteData(List<Contact> users)
        {
            var jsonData = JsonSerializer.Serialize(users);
            File.WriteAllText(_filePath, jsonData);
        }

        public Contact GetDataById(int id)
        {
            var users = ReadData();
            return users.FirstOrDefault(u => u.Id == id);
        }

    }
}