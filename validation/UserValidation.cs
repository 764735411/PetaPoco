﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using PetaPocoWebApi.Model;

namespace PetaPocoWebApi.validation
{
    public class UserValidation:AbstractValidator<User>
    {
        public UserValidation()
        {
            //验证姓名
            RuleFor(p => p.UserName).NotNull().MaximumLength(50).WithMessage("名字长度不能超过50");
        }
    }
}
