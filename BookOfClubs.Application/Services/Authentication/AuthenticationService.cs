using BookOfClubs.Application.Common.Interfaces.Authentication;

namespace BookOfClubs.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJWTTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateJWTToken(userId, firstName, lastName);
            return new AuthenticationResult(
                userId,
                firstName, 
                lastName, 
                email, 
                token
            );
        }
        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(), 
                "firstname",
                "lastname",
                email, 
                "token"
            );
        }

    }
}
