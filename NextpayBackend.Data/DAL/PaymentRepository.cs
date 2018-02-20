
using System;
using System.Linq;
using System.IO;
using NextpayBackend.Data.Models;

namespace NextpayBackend.Data.DAL
{
    public class PaymentRepository : IPaymentRepository
    {
        public bool Add(Models.Payment payment)
        {
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/Payments.txt"), true);
                writer.WriteLine(payment.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Dispose();
                    writer = null;
                }
            }

        }

        public bool LogPayment(Payment payment)
        {
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/Logs.txt"), true);                

                string strPayment = string.Format("New payment added: BSB {0} AccountNumber {1} AccountName {2} Reference {3} Amount {4}",
                payment.Bsb, payment.AccountNumber, payment.accountName, payment.Reference, payment.Amount.ToString());

                writer.WriteLine(strPayment);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Dispose();
                    writer = null;
                }
            }
        }
    }
}
