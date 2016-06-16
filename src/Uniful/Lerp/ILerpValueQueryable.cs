using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uniful
{
	/// <summary>
	/// Provides query-like access for lerp values.
	/// </summary>
	/// <typeparam name="TLerpType">Lerp value type.</typeparam>
	public interface ILerpValueQueryable<TLerpType>
	{
		/// <summary>
		/// Current value of the lerp.
		/// </summary>
		TLerpType CurrentValue { get; }

		/// <summary>
		/// Starting value from which the lerp begins from.
		/// </summary>
		TLerpType StartingValue { get; }

		/// <summary>
		/// Target end value for the lerp.
		/// </summary>
		TLerpType TargetValue { get; }
	}
}
