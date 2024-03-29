﻿using Flunt.Validations;
using System.Diagnostics.Contracts;

namespace IWantApp_API.Domain.Products
{
    public class Category:Entity
    {
        public string Name { get; private set; }
        public bool Active { get; private set; }

        public Category(string name, string createdBy, string editedBy)
        {

            Name = name;
            Active = true;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
            EditedBy = editedBy;
            EditedOn = DateTime.Now;

            Validate();
        }

        private void Validate()
        {
            var contract = new Contract<Category>()
                            .IsNotNullOrEmpty(Name, "Name")
                            .IsGreaterOrEqualsThan(Name, 3, "Name")
                            .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
                            .IsNotNullOrEmpty(EditedBy, "EditedBy");

            AddNotifications(contract);
        }

        public void EditInfo(string name, bool active)
        {
            Name = name;
            Active = active;

            Validate();
        }
    }
}
