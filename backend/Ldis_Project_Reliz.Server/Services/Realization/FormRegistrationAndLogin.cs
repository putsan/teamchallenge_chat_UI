﻿using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class FormRegistrationAndLogin : IFormRegistrationAndAuthorizationService
    {
        IRepository Repository;
        IClaimsAuthentificationService ClaimsAuthentification;
        public FormRegistrationAndLogin(IRepository Repository, IClaimsAuthentificationService ClaimsAuthentification)
        {
            this.ClaimsAuthentification = ClaimsAuthentification;
            this.Repository = Repository;
        }
        string IFormRegistrationAndAuthorizationService.FormLogin(string Email, string Password)
        {
            if (Repository.FindUserForСheckExistenceLogin(Email,Password))
            {
                ClaimsAuthentification.Authentification(Email);
                return "Реестрація успішна";
            }
            return "Користувача з таким паролем або email не існуе";
        }
        string IFormRegistrationAndAuthorizationService.FormRegistration(string UserName, string Password, string Email)
        {
            if (Repository.FindUserForСheckExistenceRegistration(Email, Password))
            {
                return "Користувач з таким іменем або паролем вже існує";
            }
            ClaimsAuthentification.Authentification(Email);
            Repository.CreateNewUser(Email,UserName,Password,null);
            return "Реестрація успішна !";
        }
    }
}
