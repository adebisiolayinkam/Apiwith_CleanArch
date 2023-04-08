using Cwk.Domain.Exceptions;
using Cwk.Domain.Validators.UserProfileValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Domain.Aggregates.UserProfileAggregate
{
    public class BasicInfo
    {
        private BasicInfo()
        {

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string Phone { get; private set; }
        public DateTime DateofBirth { get; private set; }
        public string CurrentCity { get; private set; }

        public static BasicInfo CreateBasicInfo(string FirstName, string lastName, string emailAddress,
            string phone, DateTime dateofBirth, string currentCity, out BasicInfo info)
        {

            var validator = new BasicInfoValidator();

            var objToValidate = new BasicInfo
            {
                FirstName = FirstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Phone = phone,
                DateofBirth = dateofBirth,
                CurrentCity = currentCity 
            };

            var validationResult = validator.Validate(objToValidate);

            if (validationResult.IsValid)
                info = objToValidate;
            else
            {
                info = new BasicInfo();
            }
            
            var exception = new UserProfileNotValidException("The user profile is not valid");
            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }
            return info;
            //throw exception;

        }
    }
}
