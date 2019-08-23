using MainService.NancyFX;
using Nancy;
using System;

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