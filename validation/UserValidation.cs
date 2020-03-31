using System;
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
            RuleFor(p => p.UserName).NotNull().MaximumLength(50).WithMessage("名字长度不能超过50,且不能为空");
            RuleFor(p => p.UserPhone).NotNull().Length(11).WithMessage("电话号码必须为11位");
            RuleFor(p => p.UserAge).NotNull().WithMessage("年龄不能为空");
            RuleFor(p => p.UserSex).NotNull().WithMessage("性别不能为空");
        }
    }
}
