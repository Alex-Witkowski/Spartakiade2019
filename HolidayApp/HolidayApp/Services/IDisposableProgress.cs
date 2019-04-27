using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBusyIndicator
{
	public interface IDisposableProgress<in T> :IDisposable, IProgress<T>
	{
	}
}
	