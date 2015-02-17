﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atomia.Store.Core;
using System.Web.Mvc;

namespace Atomia.Store.AspNetMvc.Adapters
{
    public class CustomerTypeProvider : ICustomerTypeProvider
    {
        private readonly IResourceProvider resourceProvider = DependencyResolver.Current.GetService<IResourceProvider>();

        public IEnumerable<CustomerType> GetCustomerTypes()
        {
            return new List<CustomerType> 
            {
                new CustomerType()
                {
                    Name = resourceProvider.GetResource("Individual"),
                    Id = "individual"
                },
                new CustomerType()
                {
                    Name = resourceProvider.GetResource("Company"),
                    Id = "company"
                }
            };
        }
    }
}
