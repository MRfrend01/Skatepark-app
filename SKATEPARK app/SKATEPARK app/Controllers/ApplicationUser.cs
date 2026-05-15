namespace SKATEPARK_app.Controllers
{
    internal class ApplicationUser
    {
        public ApplicationUser()
        {
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public bool ProfileType { get; set; }
        public string DisplayName { get; set; }
        public string AvatarImageID { get; set; }
    }
}