﻿using Cwk.Domain.Aggregates.UserProfileAggregate;
using CwkSocial.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.UserProfiles.Commands
{
    public class UpdateUserProfileBasicInfo : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public DateTime DateofBirth { get; set; }
        public string CurrentCity { get; set; }
    }
}
