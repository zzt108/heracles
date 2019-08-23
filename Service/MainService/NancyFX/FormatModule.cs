using MainService.NancyFX;
using Nancy;
using System;

namespace MainService
{
    public sealed class FormatModule : NancyModule
    {
        public FormatModule()   :base("/format")
        {
            Get("/money/{number}", _ => FormatMoney(_));
        }

        private static object FormatMoney(dynamic _)
        {

            try
            {
                return Controller.Format.Money(_.number.ToString()).ToString();
            }
            catch (Exception e)
            {
                return Helper.ErrorResponse(e,HttpStatusCode.InternalServerError);
            }
        }

    }
}