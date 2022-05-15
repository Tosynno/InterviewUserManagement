﻿using Application.Dto;
using Application.Models;
using Application.Respository;
using Application.Validations;
using AutoMapper;
using Domain;
using Domain.Entity;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OnboardingService : BaseRepository<tbl_User>, IOnboarding
    {
        private IRedisCache _redis;
        private readonly IMapper _mapper;
        public OnboardingService(AppDbContext dbContext, IRedisCache redis, IMapper mapper) : base(dbContext)
        {
            _redis = redis;
            _mapper = mapper;
        }

        public async Task<OnboardingDto> AddOnboarding(OnbardingRequest request)
        {
            
            OnboardingDto result = new OnboardingDto();
            //Deploy on IIS due to the path setting
            string webRootPath = "C:\\UserManagement\\UpLoadDoc";// _hostingEnvironment.WebRootPath + @"\Uploads\";
            if (!Directory.Exists(webRootPath))
            {
                Directory.CreateDirectory(webRootPath);
            }
            var formFile = request.Photo;
            var fileExt = request.Email + "_" + Guid.NewGuid().ToString() + "_" + formFile.FileName;
            var filePath = Path.Combine(webRootPath, fileExt);



            using (var stream = System.IO.File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }

                var checkotp = await Verifyotp(request.Email, request.Otp);
            if (checkotp == true)
            {
                var sa = _mapper.Map<tbl_User>(request);
                sa.Photo = filePath;
                await AddAsync(sa);
                //using JWT to generate token 
                result.Token = "85e87dghubcjndkjnfdkjkdcijjfdhjjhdjhvjhdjhvdjhfgedysfeycdtucdw";
                result.ResponseCode = "00";
                result.Message = "Onboarding was Succesful";
                
            }
            else
            {
                var cheotp = await Verifyotp(request.Phone, request.Otp);
                if (cheotp == true)
                {
                        var sa = _mapper.Map<tbl_User>(request);
                        sa.Photo = filePath;
                        await AddAsync(sa);
                        await AddAsync(sa);
                    result.Token = "85e87dghubcjndkjnfdkjkdcijjfdhjjhdjhvjhdjhvdjhfgedysfeycdtucdw";
                    result.ResponseCode = "00";
                    result.Message = "Onboarding was Succesful";
                }
                else
                {
                    result.ResponseCode = "99";
                    result.Message = "Fail to Onboarding Customer at this time, Kindly Contact the support person";
                }
              
            }
           
            
            return result;
        }

        public async Task<List<OnboardingResponse>> GetAllOnboarding()
        {
            var result = await GetAllAsync();
            var res = _mapper.Map<List<OnboardingResponse>>(result);
            return res;
        }

        public async Task<OnboardingResponse> GetOnboardingByEmail(string Email)
        {
            var result = await GetAllAsync();
            var getres = result.FirstOrDefault(c => c.Email == Email);
            var res = _mapper.Map<OnboardingResponse>(getres);
            return res;
        }

        public async Task<OnboardingResponse> GetOnboardingByPhone(string Phone)
        {
            var result = await GetAllAsync();
            var getres = result.FirstOrDefault(c => c.Email == Phone);
            var res = _mapper.Map<OnboardingResponse>(getres);
            return res;
        }

        public Task<string> GetToken(string Token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyEmail(string Email)
        {
            Random d = new Random();
            var otpinput = d.Next(100000, 999999).ToString();

            //save otp in redis or any other cache
            var saveotp = await _redis.PostOTP(Email, otpinput);
            if (saveotp == true)
                //send otp using sendgrip, sendblue, twillo, infobiz, mountimobi etc, this processor 
                //help pass customer infomation and also help organisation pass info to their customer by email or mobile device
                return true;
            return false;
        }

        public async Task<bool> Verifyotp(string PhoneorEmail, string input)
        {
            var saveotp = await _redis.GetOTP(PhoneorEmail);
            if (saveotp == input)
                return true;
            return false;
        }

        public async Task<bool> VerifyPhone(string Phone)
        {
            Random d = new Random();
            var otpinput = d.Next(100000, 999999).ToString();

            var saveotp = await _redis.PostOTP(Phone, otpinput);
            if (saveotp == true)
            return true;
            return false;
        }
    }
}
