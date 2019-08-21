using EasyNetQ;

namespace Udemy.Merchant.Bus
{
    public static class Factory
    {
        public static IBus PrepareBus(string username, string password)
        {
            string connection = $"host=localhost;virtualhost=merchant;username={username};password={password}";

            return RabbitHutch.CreateBus(connection);
        }
    }
}