﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using El_Proyecte_Grande.Utils;

namespace El_Proyecte_Grande.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Column(TypeName = "varchar(30)")]
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        [MaxLength(30)]
        public string Position { get; set; }
        public GenderTypes Gender { get; set; }
        public Address Address { get; set; }
        public ProfessionalApproach ProfessionalApproach { get; set; }
        public PersonalApproach PersonalApproach { get; set; }

        //Relationship

        //Deal (OneToManyToManyToOne)
        public virtual List<Client_Deal> Deals { get; set; }

        //SocialMedia (OneToMany)
        public virtual List<SocialMedia> SocialMedias { get; set; }


    }
}
