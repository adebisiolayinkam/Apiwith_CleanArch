﻿using Cwk.Domain.Aggregates.PostAggregate;
using CwkSocial.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.Posts.Queries
{
    public class GetAllPosts : IRequest<OperationResult<List<Post>>>
    {

    }
}
