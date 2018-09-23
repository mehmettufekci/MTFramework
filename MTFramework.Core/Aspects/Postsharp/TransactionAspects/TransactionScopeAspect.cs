using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MTFramework.Core.Aspects.Postsharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        //Eğer parametre kullanılacaksa
        private TransactionScopeOption _option;
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;

            //Option parametreleri için örnek kullanım
            //using (TransactionScope scope = new TransactionScope())
            //{

            //}
        }
        // Herhangi bir transactionscope değeri girilmediğinde
        public TransactionScopeAspect()
        {

        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}