﻿namespace AfisolProject.Models.DTO
{
    public class AddContactDTO
    {

        public int ContactId { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Tel { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public int? CountryId { get; set; }
    }
}
