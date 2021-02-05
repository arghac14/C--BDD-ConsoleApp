using System;
using System.Collections.Generic;
using System.Text;
using IMDBapp.Domain;
using System.Linq;

namespace IMDBapp.Repository
{
    public class ProducerRepository
    {
        public List<Producer> _producers;

        public ProducerRepository() {
            _producers = new List<Producer>();
        }

        public void AddProducerData(Producer producer)
        {
            _producers.Add(producer);
        }
        public List<Producer> GetProducersData()
        {
            return _producers.ToList();
        }
    }
}
