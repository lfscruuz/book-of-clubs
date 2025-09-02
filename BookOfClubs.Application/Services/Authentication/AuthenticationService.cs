using BookOfClubs.Application.Common.Interfaces.Authentication;
using BookOfClubs.Application.Common.Interfaces.Persistance;
using BookOfClubs.Domain.Entities;

namespace BookOfClubs.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("Email already registered.");
            }
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateJWTToken(user);
            return new AuthenticationResult(
                user,
                token
            );
        }
        public AuthenticationResult Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user is not User || user.Password != password)
            {
                throw new Exception("Email or password is incorrect");
            }
            var token = _jwtTokenGenerator.GenerateJWTToken(user);

            return new AuthenticationResult(
                user,
                token
            );
        }

    }
}
