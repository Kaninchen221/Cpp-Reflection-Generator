#define RNamespace(...)
#define RClass(...)
#define REnum(...)
#define RMethod(...)
#define RMember(...)
#define RStruct(...)
#define RFunction(...)

RNamespace();							/// Identife this line as Reflection instruction, then jump to next line
namespace MyNamespace{					/// Parse this line as namespace declaration, then identife this as declaration with definition and "go inside"
										/// Ignore empty line
	class NoReflectClass {				/// Ignore not Reflected class declaration
		void foo();						/// Ignore not interesting class definition
	};									/// Ignore not interesting class end of declaration
										/// Ignore empty line
	REnum();								/// Identife this line as Reflection instruction, then jump to next line
	enum MyEnum {						/// Parse this line as enum declaration, then identife this as declaration with definition and "go inside"
										/// Ignore empty line
	};									/// Identife this line as end of enum definition and "go outside"
										/// Ignore empty line
	RClass();							/// Identife this line as Reflection instruction, then jump to next line
	class MyClass {						/// Parse this line as class declaration, then identife this as declaration with definition and "go inside"
										/// Ignore empty line
		RMethod();						/// Identife this line as Reflection instruction, then jump to next line
		void PrivateFunction() {}		/// Parse this line as method declaration and ignore lines to end of method definition
										/// Ignore empty line
	protected:							/// Identife Access Specifier
										/// Ignore empty line
		RMethod();						/// Identife this line as Reflection instruction, then jump to next line
		void ProtectedFunction() {}		/// Parse this line as method declaration and ignore lines to end of method definition
										/// Ignore empty line
	public:								/// Identife Access Specifier
										/// Ignore empty line
		RMember();					/// Identife this line as Reflection instruction, then jump to next line
		inline static int Counter = 0;	/// Parse this line as member declaration
										/// Ignore empty line
		RMethod();						/// Identife this line as Reflection instruction, then jump to next line
		void PublicFunction() {}		/// Parse this line as method declaration and ignore lines to end of method definition
										/// Ignore empty line
		//class NoReflectClass {...		/// Reflected class can't have not reflected classes
										/// Ignore empty line
		RStruct();						/// Identife this line as Reflection instruction, then jump to next line
		struct MyStructInsideClass {	/// Parse this line as class declaration, then identife this as declaration with definition and "go inside"
										/// Ignore empty line
		};								/// Identife this line as end of class definition and "go outside"
										/// Ignore empty line
	};									/// Identife this line as end of class definition and "go outside"
										/// Ignore empty line
	RFunction();						/// Identife this line as Reflection instruction, then jump to next line
	void MyFreeFunction() {				/// Parse this line as method declaration and ignore lines to end of method definition
										/// Ignore because we are inside method definition
	}									/// Identife this line as end of method definition and stop ignoring next lines
										/// Ignore empty line
}										/// Identife this line as end of namespace definition and "go outside"