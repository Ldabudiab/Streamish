using Streamish.Models;

namespace Streamish.Repositories
{
    public interface IUserProfileRepository
    {
        UserProfile GetByIdWithVideos(int id);
        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
    }
}