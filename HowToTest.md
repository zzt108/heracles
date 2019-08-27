# How to setup environment
## How to compile sources
Sources can be found on Github at https://github.com/zzt108/heracles/tree/ZuluTango
The latest work is on branch ZuluTango

### Visual Studio Community Edition
Compilation is easiest to do in Microsoft Visual Studio 2019 Community Edition.
Open the solution file **Service.sln** from **Service folder** in Visual Studio.
Then in the **Build Menu** select **Build Solution**
The binaries should be compiled without problem, however Visual Studio 2019 sometimes have issues accessing some of the external libraries (nuget packages). In this case the build process would fail. 
In this case I can provide the compiled binaries and the tests could be executed by NUnit test executor. [See below](#In NUnit Test runner).

## How to execute tests
Before executing the tests, please do configure the tests as described [below](#How to setup automated test)

## In Visual Studio
Open Test Explorer window in menu Test/Windows/Test Explorer
The available tests should be seen in the left side of the window in a collapsed tree view.
Press the button **Run All** above the tree view.
All tests should be green after execution.

## In NUnit Test runner
Execute **runTests.bat** file in **Service** folder
1. Please see [NUnit test runner installation](https://stackoverflow.com/questions/45482507/how-do-i-install-nunit-3-console-on-windows-and-run-tests)
2. If Visual Studio compilation is succesfull, test runner is also deployed into packages folder, so runtests.bat is expecting it to be there.
3. If test runner is installed manually, runtests.bat needs to be changed to search for it at the correct place
# How to setup automated test
## UI test setup
### Selenium
1. <a id="driversId">Get and put Selenium browser drivers from WEB</a>

[GitHub](https://github.com/lmc-eu/steward/wiki/Selenium-server-&-browser-drivers)

[SeleniumHQ](https://www.seleniumhq.org/download/)

2. Put the drivers onto search path, or in the same folder as the executable
### Client page folder
1. Set the client page path in the test app configuration file [See Example](#exampleId)

2. Set the MainService.exe path (and optionally the name) in the test app configuration file [See Example](#exampleId): 

3. Setup the enabled browsers. If multiple browsers enabled then the tests are executed on each of them. Remember to download and deploy the browser drivers [See](#driversId)
4. <a id="exampleId">Example configuration</a>
```xml
  <appSettings>
      <add key="TestedProcess" value="mainservice.exe" />
      <add key="TestedProcessPath" value="c:\Git\Pleo\heracles\Service\MainService\bin\Debug\" />
      <add key="WebSiteRoot" value="c:\Git\Pleo\heracles\Service\Client\" />
      <add key="ImplicitWaitMilliseconds" value="5000" />
      <!--Browser selection-->
      <add key="FirefoxEnabled" value="false" />
      <add key="ChromeEnabled" value="true" />
      <add key="EdgeEnabled" value="false" />
      <add key="InternetExplorerEnabled" value="false" />
    </appSettings>
```  