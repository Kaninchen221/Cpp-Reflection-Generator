namespace zt {
	
	template<class T>
	class NormalClass {
		
	public:
		int testValue = 10;
		
		T objectOfTemplateParamType;
		
		template<class T>
		void DoSomething(T t);
		
	};
	
}