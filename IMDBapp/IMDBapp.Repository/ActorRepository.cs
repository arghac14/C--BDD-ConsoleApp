using System;
using System.Collections.Generic;
using IMDBapp.Domain;
using System.Text;
using System.Linq;

namespace IMDBapp.Repository
{
    public class ActorRepository
    {
        public List<Actor> _actors;
        public ActorRepository()
        {
            _actors = new List<Actor>();   
        }

        public void AddActorData(Actor actor)
        {
            _actors.Add(actor);
        }
        public List<Actor> GetActorsData()
        {
            return _actors.ToList();
        }

    }
}
