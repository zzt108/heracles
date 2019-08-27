#Plan/Acceptance criteria
	1. AC: Create simple web page/REST service/backend in Dotnet C# as specified in Readme.md
		1. AC: testable architecture
		2. Implement rounding to 2 decimal places
	2. AC: Create as much automated test as possible
		1. Unit tests of the backend, data driven test, mock testing?
		2. Integration test. 
			1. a RESTful service with NancyFx self hosted service
		3. Fuzzy testing, mutation testing
		3. BDD/Cucumber
		3. UI test with Selenium
			1. Update and include Selenium C# base project
		4. Performance test (Code profiling, JMeter?, Performance Reguirements)
	3. AC: Result of AC 1. and 2. must be testable 
		1. Create test environment in Amazon EC2
		2. Deploy web app, tests and test frameworks (Selenium and MS test agents)
		3. Give access to the AWS instance
		4. Document of test process
	3. Alternative AC: Use Visual Studio Community edition or NUnit test runner as test environment
 