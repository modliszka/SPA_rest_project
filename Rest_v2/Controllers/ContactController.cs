﻿using Rest_v2.Models;
using Rest_v2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rest_v2.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository contactRepository;

        public ContactController() {
            this.contactRepository = new ContactRepository();
        } 

        public Contact[] Get() {
            return this.contactRepository.GetAllContacts();
        }
    }
}