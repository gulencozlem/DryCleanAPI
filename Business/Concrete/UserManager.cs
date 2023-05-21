using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IHttpContextAccessor _httpContextAccessor;
        public UserManager(IUserDal userDal, IHttpContextAccessor httpContextAccessor)
        {
            _userDal = userDal;
            _httpContextAccessor = httpContextAccessor;
            
        }

        //public List<OperationClaim> GetClaims(User user)
        //{
        //    return _userDal.GetClaims(user);
        //}

        //public void Add(User user)
        //{
        //    _userDal.Add(user);
        //}

        
        public IResult Add(User user)
        {
            _userDal.Add(user);
            
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IResult Update(UserForUpdateDto user)
        {
            User userToUpdate = _userDal.Get(u => u.Id == user.Id);
            if (userToUpdate == null)
            {
                return new ErrorResult();
            }
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            _userDal.Update(userToUpdate);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<User>();
            }
            else
            {
                return new SuccessDataResult<User>(result);
            }
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result == null)
            {
                return new ErrorDataResult<User>();
            }
            else
            {
                return new SuccessDataResult<User>(result);
            }
        }
        //public User GetByMail(string email)
        //{
        //    return _userDal.Get(u => u.Email == email);
        //}
        [Authentication]
        public IDataResult<User> GetDetails()
        {
            int authUserId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var result = _userDal.Get(u => u.Id == authUserId);
            if (result == null)
            {
                return new ErrorDataResult<User>();
            }
            else
            {
                return new SuccessDataResult<User>(result);
            }
        }
    }
}
