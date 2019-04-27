using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SmartBusyIndicator.Annotations;

namespace SmartBusyIndicator
{
	public class BusyHandler : INotifyPropertyChanged
	{
		private int _counter;

		public BusyHandler()
		{
			IndeterminateLockObject = new object();
			ProgressLockObject = new object();
			ProgressDict = new Dictionary<Guid, ProgressReport>();
		}

		int Counter
		{
			get { return _counter; }
			set
			{
				if (value == _counter) return;
				_counter = value;
				OnPropertyChanged("IsBusy");
			}
		}

		public double Progress{get { lock(ProgressLockObject){return ProgressDict.Any() ? (ProgressDict.Values.Sum(obj => obj.Progress) / ProgressDict.Count ): 0;} }}

		object IndeterminateLockObject { get; set; }
		object ProgressLockObject { get; set; }

		Dictionary<Guid, ProgressReport> ProgressDict { get; set; } 

		public bool IsBusy { get { return Counter > 0; } }
		public IDisposable Activate()
		{
			return new DisposableBusyHandler(this);
		}		
		
		public IDisposableProgress<double> ActivateWithProgress()
		{
			return new DisposableBusyHandlerWithProgress(this);
		}


		class DisposableBusyHandler : IDisposable
		{
			private readonly BusyHandler _handler;

			public DisposableBusyHandler(BusyHandler handler)
			{
				_handler = handler;
				lock (_handler.IndeterminateLockObject)
				{
					_handler.Counter++;
				}
			}

			public void Dispose()
			{
				lock (_handler.IndeterminateLockObject)
				{
					_handler.Counter--;
				}
			}
		}

		class ProgressReport
		{
			public double Progress { get; set; }
			public bool IsFinished { get; set; }
		}

		class DisposableBusyHandlerWithProgress : IDisposableProgress<double>
		{
			private readonly BusyHandler _handler;
			private readonly Guid _id;
			public DisposableBusyHandlerWithProgress(BusyHandler handler)
			{
				_id = Guid.NewGuid();
				_handler = handler;
				lock (_handler.ProgressLockObject)
				{
					_handler.ProgressDict.Add(_id,new ProgressReport());
					foreach (var finished in _handler.ProgressDict.Where(itm => itm.Value.IsFinished).ToList())
					{
						_handler.ProgressDict.Remove(finished.Key);
					}
				}
			}

			public void Dispose()
			{
				lock (_handler.ProgressLockObject)
				{
					_handler.ProgressDict[_id].IsFinished = true;
					if (_handler.ProgressDict.All(itm => itm.Value.IsFinished))
					{
						_handler.ProgressDict.Clear();
					}
				}
				_handler.OnPropertyChanged("Progress");
			}

			public void Report(double value)
			{
				lock (_handler.ProgressLockObject)
				{
					_handler.ProgressDict[_id].Progress = value;
				}
				_handler.OnPropertyChanged("Progress");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
