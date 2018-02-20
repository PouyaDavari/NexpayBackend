using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextpayBackend.Data.DAL
{
    public interface IPaymentRepository
    {
        bool Add(Models.Payment payment);        
        bool LogPayment(Models.Payment payment);
    }
}
