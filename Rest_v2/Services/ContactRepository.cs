﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rest_v2.Models;

//http://www.asp.net/web-api/overview/older-versions/build-restful-apis-with-aspnet-web-api

namespace Rest_v2.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";

        public ContactRepository() {
            var ctx = HttpContext.Current;

            if (ctx != null) {
                if (ctx.Cache[CacheKey] == null) {
                    var contacts = new Contact[] {
                        new Contact {
                            Id = 1, Name = "Glenn Block"
                        },
                        new Contact {
                            Id = 2, Name = "Dan Roth"
                        }
                    };

                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }

        public Contact[] GetAllContacts() {
            var ctx = HttpContext.Current;

            if (ctx != null) {
                return (Contact[])ctx.Cache[CacheKey];
            }

            return new Contact[] {
                new Contact {
                    Id = 0,
                    Name = "Placeholder"
                }
            };

            /*return new Contact[] {
                new Contact {
                    Id = 1,
                    Name = "Glenn Block"
                },
                new Contact {
                    Id = 2,
                    Name = "Dan Roth"
                }
            };*/
        }

        public bool SaveContact(Contact contact)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(contact);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}