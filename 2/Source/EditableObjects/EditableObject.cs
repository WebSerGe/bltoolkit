using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Reflection;

using BLToolkit.Mapping;
using BLToolkit.Reflection;
using BLToolkit.TypeBuilder;
using BLToolkit.ComponentModel;
using BLToolkit.Validation;

namespace BLToolkit.EditableObjects
{
	#region Instance Types
	//[GlobalInstanceType(typeof(EditableObject), typeof(EditableObjectHolder), IsObjectHolder=true)]
#if FW2
	[GlobalInstanceType(typeof(byte),     typeof(EditableValue<byte>))]
	[GlobalInstanceType(typeof(char),     typeof(EditableValue<char>))]
	[GlobalInstanceType(typeof(ushort),   typeof(EditableValue<ushort>))]
	[GlobalInstanceType(typeof(uint),     typeof(EditableValue<uint>))]
	[GlobalInstanceType(typeof(ulong),    typeof(EditableValue<ulong>))]
	[GlobalInstanceType(typeof(bool),     typeof(EditableValue<bool>))]
	[GlobalInstanceType(typeof(sbyte),    typeof(EditableValue<sbyte>))]
	[GlobalInstanceType(typeof(short),    typeof(EditableValue<short>))]
	[GlobalInstanceType(typeof(int),      typeof(EditableValue<int>))]
	[GlobalInstanceType(typeof(long),     typeof(EditableValue<long>))]
	[GlobalInstanceType(typeof(float),    typeof(EditableValue<float>))]
	[GlobalInstanceType(typeof(double),   typeof(EditableValue<double>))]
	[GlobalInstanceType(typeof(string),   typeof(EditableValue<string>), "")]
	[GlobalInstanceType(typeof(DateTime), typeof(EditableValue<DateTime>))]
	[GlobalInstanceType(typeof(decimal),  typeof(EditableValue<decimal>))]
	[GlobalInstanceType(typeof(Guid),     typeof(EditableValue<Guid>))]

	[GlobalInstanceType(typeof(byte?),     typeof(EditableValue<byte?>))]
	[GlobalInstanceType(typeof(char?),     typeof(EditableValue<char?>))]
	[GlobalInstanceType(typeof(ushort?),   typeof(EditableValue<ushort?>))]
	[GlobalInstanceType(typeof(uint?),     typeof(EditableValue<uint?>))]
	[GlobalInstanceType(typeof(ulong?),    typeof(EditableValue<ulong?>))]
	[GlobalInstanceType(typeof(bool?),     typeof(EditableValue<bool?>))]
	[GlobalInstanceType(typeof(sbyte?),    typeof(EditableValue<sbyte?>))]
	[GlobalInstanceType(typeof(short?),    typeof(EditableValue<short?>))]
	[GlobalInstanceType(typeof(int?),      typeof(EditableValue<int?>))]
	[GlobalInstanceType(typeof(long?),     typeof(EditableValue<long?>))]
	[GlobalInstanceType(typeof(float?),    typeof(EditableValue<float?>))]
	[GlobalInstanceType(typeof(double?),   typeof(EditableValue<double?>))]
	[GlobalInstanceType(typeof(DateTime?), typeof(EditableValue<DateTime?>))]
	[GlobalInstanceType(typeof(decimal?),  typeof(EditableValue<decimal?>))]
	[GlobalInstanceType(typeof(Guid?),     typeof(EditableValue<Guid?>))]

	[GlobalInstanceType(typeof(SqlBoolean),  typeof(EditableValue<SqlBoolean>))]
	[GlobalInstanceType(typeof(SqlByte),     typeof(EditableValue<SqlByte>))]
	[GlobalInstanceType(typeof(SqlDateTime), typeof(EditableValue<SqlDateTime>))]
	[GlobalInstanceType(typeof(SqlDecimal),  typeof(EditableValue<SqlDecimal>))]
	[GlobalInstanceType(typeof(SqlDouble),   typeof(EditableValue<SqlDouble>))]
	[GlobalInstanceType(typeof(SqlGuid),     typeof(EditableValue<SqlGuid>))]
	[GlobalInstanceType(typeof(SqlInt16),    typeof(EditableValue<SqlInt16>))]
	[GlobalInstanceType(typeof(SqlInt32),    typeof(EditableValue<SqlInt32>))]
	[GlobalInstanceType(typeof(SqlInt64),    typeof(EditableValue<SqlInt64>))]
	[GlobalInstanceType(typeof(SqlMoney),    typeof(EditableValue<SqlMoney>))]
	[GlobalInstanceType(typeof(SqlSingle),   typeof(EditableValue<SqlSingle>))]
	[GlobalInstanceType(typeof(SqlString),   typeof(EditableValue<SqlString>), "")]

#else
	[AttributeUsage(AttributeTargets.Class)]
	class Instance : GlobalInstanceTypeAttribute
	{ public Instance(object value) : base(value.GetType(), typeof(EditableValue), value) {} }

	class DateTimeInstance : Instance { public DateTimeInstance() : base(DateTime.MinValue) {} }
	class DecimalInstance  : Instance { public DecimalInstance()  : base(0m)                {} }
	class GuidInstance     : Instance { public GuidInstance()     : base(Guid.Empty)        {} }

	class SqlBooleanInstance     : Instance { public SqlBooleanInstance()     : base(SqlBoolean.Null)  {} }
	class SqlByteInstance        : Instance { public SqlByteInstance()        : base(SqlByte.Null)     {} }
	class SqlDateTimeInstance    : Instance { public SqlDateTimeInstance()    : base(SqlDateTime.Null) {} }
	class SqlDecimalTimeInstance : Instance { public SqlDecimalTimeInstance() : base(SqlDecimal.Null)  {} }
	class SqlDoubleInstance      : Instance { public SqlDoubleInstance()      : base(SqlDouble.Null)   {} }
	class SqlGuidInstance        : Instance { public SqlGuidInstance()        : base(SqlGuid.Null)     {} }
	class SqlInt16Instance       : Instance { public SqlInt16Instance()       : base(SqlInt16.Null)    {} }
	class SqlInt32Instance       : Instance { public SqlInt32Instance()       : base(SqlInt32.Null)    {} }
	class SqlInt64Instance       : Instance { public SqlInt64Instance()       : base(SqlInt64.Null)    {} }
	class SqlMoneyInstance       : Instance { public SqlMoneyInstance()       : base(SqlMoney.Null)    {} }
	class SqlSingleInstance      : Instance { public SqlSingleInstance()      : base(SqlSingle.Null)   {} }
	class SqlStringInstance      : Instance { public SqlStringInstance()      : base(SqlString.Null)   {} }

	[GlobalInstanceType(typeof(byte),   typeof(EditableValue), (byte)0)]
	[GlobalInstanceType(typeof(char),   typeof(EditableValue), (char)0)]
	[GlobalInstanceType(typeof(ushort), typeof(EditableValue), (ushort)0)]
	[GlobalInstanceType(typeof(uint),   typeof(EditableValue), (uint)0)]
	[GlobalInstanceType(typeof(ulong),  typeof(EditableValue), (ulong)0)]
	[GlobalInstanceType(typeof(bool),   typeof(EditableValue), false)]
	[GlobalInstanceType(typeof(sbyte),  typeof(EditableValue), (sbyte)0)]
	[GlobalInstanceType(typeof(short),  typeof(EditableValue), (short)0)]
	[GlobalInstanceType(typeof(int),    typeof(EditableValue), (int)0)]
	[GlobalInstanceType(typeof(long),   typeof(EditableValue), (long)0)]
	[GlobalInstanceType(typeof(float),  typeof(EditableValue), (float)0)]
	[GlobalInstanceType(typeof(double), typeof(EditableValue), (double)0)]
	[GlobalInstanceType(typeof(string), typeof(EditableValue), "")]
	[DateTimeInstance,   DecimalInstance,  GuidInstance]
	[SqlBooleanInstance, SqlByteInstance,  SqlDateTimeInstance, SqlDecimalTimeInstance]
	[SqlDoubleInstance,  SqlGuidInstance,  SqlInt16Instance,    SqlInt32Instance]
	[SqlInt64Instance,   SqlMoneyInstance, SqlSingleInstance,   SqlStringInstance]
#endif
	#endregion
	[ImplementInterface(typeof(IEditable))]
	[ImplementInterface(typeof(IMemberwiseEditable))]
	[ImplementInterface(typeof(IPrintDebugState))]
	public abstract class EditableObject
		: IEditableObject, IValidatable, INotifyPropertyChanged, ISupportMapping, IPropertyChanged, INotifyObjectEdit
	{
		#region IEditable

		public virtual void AcceptChanges()
		{
			if (this is IEditable)
				((IEditable)this).AcceptChanges();
		}

		public virtual void RejectChanges()
		{
			if (this is IEditable)
				((IEditable)this).RejectChanges();
		}

		[MapIgnore, Bindable(false)]
		public virtual bool IsDirty
		{
			get { return this is IEditable? ((IEditable)this).IsDirty: false; }
		}

		public virtual void AcceptMemberChanges(string memberName)
		{
			if (this is IMemberwiseEditable)
				((IMemberwiseEditable)this).AcceptMemberChanges(null, memberName);
		}

		public virtual void RejectMemberChanges(string memberName)
		{
			if (this is IMemberwiseEditable)
				((IMemberwiseEditable)this).RejectMemberChanges(null, memberName);
		}

		public virtual bool IsDirtyMember(string memberName)
		{
			bool isDirty = false;

			if (this is IMemberwiseEditable)
				((IMemberwiseEditable)this).IsDirtyMember(null, memberName, ref isDirty);

			return isDirty;
		}

		public virtual PropertyInfo[] GetDirtyMembers()
		{
			ArrayList list = new ArrayList();

			if (this is IMemberwiseEditable)
				((IMemberwiseEditable)this).GetDirtyMembers(null, list);

			return (PropertyInfo[])list.ToArray(typeof(PropertyInfo));
		}

		[MapIgnore, Bindable(false)]
		public virtual string PrintDebugState
		{
			get
			{
#if DEBUG
				if (this is IPrintDebugState)
				{
					string s = string.Format(
						"====== {0} ======\r\nIsDirty: {1}\r\n" +
						"Property       IsDirty Original                                 Current\r\n" +
						"==================== = ======================================== ========================================\r\n",
						GetType().Name, IsDirty);

					((IPrintDebugState)this).PrintDebugState(null, ref s);

					return s + "\r\n";
				}
#endif
				return "";
			}
		}

		#endregion

		#region ISupportMapping Members

		private bool _inMapping;
		[MapIgnore, Bindable(false)]
		public  bool  InMapping
		{
			get { return _inMapping; }
		}

		public void BeginMapping(InitContext initContext)
		{
			_inMapping = true;
		}

		public void EndMapping(InitContext initContext)
		{
			AcceptChanges();

			_inMapping = false;

			OnPropertyChanged("");
		}

		#endregion

		#region Notify Changes

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (NotifyChanges && PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		private bool _notifyChanges = true;
		[MapIgnore, Bindable(false)]
		public  bool  NotifyChanges
		{
			get { return _notifyChanges;  }
			set { _notifyChanges = value; }
		}

		#endregion

		#region IPropertyChanged Members

		void IPropertyChanged.OnPropertyChanged(PropertyInfo propertyInfo)
		{
			if (_inMapping == false)
				OnPropertyChanged(propertyInfo.Name);
		}

		#endregion

		#region INotifyPropertyChanged Members

		public virtual event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region IEditableObject Members

		public virtual void BeginEdit()
		{
			if (ObjectEdit != null)
				ObjectEdit(this, new ObjectEditEventArgs(ObjectEditType.Begin));
		}

		public virtual void CancelEdit()
		{
			if (ObjectEdit != null)
				ObjectEdit(this, new ObjectEditEventArgs(ObjectEditType.Cancel));
		}

		public virtual void EndEdit()
		{
			if (ObjectEdit != null)
				ObjectEdit(this, new ObjectEditEventArgs(ObjectEditType.End));
		}

		#endregion

		#region INotifyObjectEdit Members

		public event ObjectEditEventHandler ObjectEdit;

		#endregion

		#region Validation

		public virtual void Validate()
		{
			Validator.Validate(this);
		}

		public virtual bool IsValid(string fieldName)
		{
			return Validator.IsValid(this, fieldName);
		}

		public virtual string[] GetErrorMessages(string fieldName)
		{
			return Validator.GetErrorMessages(this, fieldName);
		}

		#endregion
	}
}
