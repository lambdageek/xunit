﻿// TODO: Can we/should we figure out a unique ID for tests?

using System;

#if XUNIT_FRAMEWORK
namespace Xunit.v3
#else
namespace Xunit.Runner.v3
#endif
{
	/// <summary>
	/// Base message for all messages related to tests.
	/// </summary>
	public class _TestMessage : _TestCaseMessage
	{
		string? testDisplayName;

		/// <summary>
		/// Gets or sets the display name of the test.
		/// </summary>
		public string TestDisplayName
		{
			get => testDisplayName ?? throw new InvalidOperationException($"Attempted to get {nameof(TestDisplayName)} on an uninitialized '{GetType().FullName}' object");
			set => testDisplayName = Guard.ArgumentNotNullOrEmpty(nameof(TestDisplayName), value);
		}
	}
}
