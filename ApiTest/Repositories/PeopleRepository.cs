using ApiTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Repositories
{
    public class PeopleRepository : IDisposable
    {
        private PeopleRoot _peopleRoot;
        private string _filePath;
        public List<Person> People => _peopleRoot.People;
        public PeopleRepository()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.json");
            string peopleJson = File.ReadAllText(_filePath);
            _peopleRoot = JsonConvert.DeserializeObject<PeopleRoot>(peopleJson);
        }
        public List<Person> AllPersons()
        {
            return People;
        }

        public List<Person> MatchingPersons(string searchText)
        {
            return People.Where(person => !string.IsNullOrEmpty(person.Name) && person.Name.ToUpper().Contains(searchText.ToUpper())).ToList();
        }

        public async Task SaveChanges()
        {
            string peopleJson = JsonConvert.SerializeObject(_peopleRoot, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, peopleJson);
        }
        public async Task AddPerson(Person person)
        {
            int maxId = People.Max(person => person.Id);
            person.Id = ++maxId;
            _peopleRoot.People.Add(person);
            await SaveChanges();
        }

        public async Task ModifyPerson(Person person)
        {
            Person targetPerson = People.FirstOrDefault(prs => prs.Id == person.Id);
            if (targetPerson == null) throw new Exception();
            targetPerson.Name = person.Name;
            targetPerson.Age = person.Age;
            await SaveChanges();
        }

        public Person FindPerson(int Id)
        {
            return People.FirstOrDefault(prs => prs.Id == Id);
        }

        public async Task DeletePerson(Person person)
        {
            People.Remove(person);
            await SaveChanges();
        }

        public void Dispose()
        {
            // placehoder for any explicit release of resources
            GC.SuppressFinalize(this);
        }

    }
}
