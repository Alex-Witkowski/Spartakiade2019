using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBusyIndicator
{
	public static class ProgressExtensions
	{
		public static IEnumerable<T> WithProgressReport<T>(this IEnumerable<T> source, IProgress<double> progressHandler,
			int itemCount, double reportInterval)
		{

			var reportingCountInterval = (int)(itemCount / (100/reportInterval));
			var counter = 0;
			foreach (var item in source)
			{
				yield return item;
				counter++;
				if (counter % reportingCountInterval == 0)
				{
					progressHandler.Report(counter * 100.0 / itemCount);
				}
			}
		}
	
		public static IEnumerable<T> WithProgressReport<T>(this ICollection<T> source, IProgress<double> progressHandler,double reportInterval = 0.1)
		{
			return source.WithProgressReport(progressHandler, source.Count, reportInterval);
		}
		public static IEnumerable<T> WithProgressReport<T>(this T[] source, IProgress<double> progressHandler,double reportInterval = 0.1)
		{
			return source.WithProgressReport(progressHandler, source.Length, reportInterval);
		}
	}
}
