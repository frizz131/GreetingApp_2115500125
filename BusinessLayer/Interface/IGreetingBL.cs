﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.DTO;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        string GetGreetingMessage(string firstname, string lastname);
        string GetPersonalizedGreeting(GreetingRequestModel request);
        bool AddGreeting(GreetingDTO greetingDTO); 
    }
}
