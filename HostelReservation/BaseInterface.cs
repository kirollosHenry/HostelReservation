using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation
{
    public interface IBaseInterface
    {
        public void Create(object CreateObj);

        public void Read(object ReadObj);

        public void Update(object UpdateObj);

        public void Delete(object DeleteObj);
    }
}
