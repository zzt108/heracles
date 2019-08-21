using Nancy;

namespace MainService
{
    public sealed class MainModule : NancyModule
    {
        public MainModule()
        {
            Get("/", _ => "Main service");
        }
    }
}