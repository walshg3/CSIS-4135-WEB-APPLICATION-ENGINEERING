namespace TheFriendShip.Data {
   public class LoginVM {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginReturn
    {
        public string user { get; set; }
        public string tokenString { get; set; }
    }
}
