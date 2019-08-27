# 1. How to setup environment
## 1.1. How to compile sources
Sources can be found on Github at https://github.com/zzt108/heracles/tree/ZuluTango
The latest work is on branch ZuluTango

### 1.1.1. Visual Studio Community Edition
Compilation is easiest to do in Microsoft Visual Studio 2019 Community Edition.
Open the solution file **Service.sln** from **Heracles/Service** folder in Visual Studio.
To compile select **Build Solution** in the **Build Menu** .

The binaries should be compiled without problem, however Visual Studio 2019 sometimes have issues accessing some of the external libraries (nuget packages). In this case the build process would fail. 

If build is unsuccessfull
1. In **Tools/Nuget Package Manager/Manage Nuget Packages for Solution ...** menu the missing packages can be forced to be downloaded by selecting a previous version to be installed for them. Then upgrading the packages again to the latest version will download them correctly.
2. Alternatively I can provide the compiled binaries and the tests could be executed by NUnit test executor. [See below](#122-In-NUnit-Test-runner).

## 1.2. How to execute tests
Before executing the tests, please do configure the tests as described [below](#2-how-to-setup-automated-test)

## 1.2.1. In Visual Studio
Open Test Explorer window in menu Test/Windows/Test Explorer
The available tests should be seen in the left side of the window in a collapsed tree view.
Press the button **Run All** above the tree view.
All tests should be green after execution.

## 1.2.2. In NUnit Test runner
Execute **runTests.bat** file in **Heracles/Service** folder
1. Please see [NUnit test runner installation](https://stackoverflow.com/questions/45482507/how-do-i-install-nunit-3-console-on-windows-and-run-tests) if compilation was not successfull
2. If Visual Studio compilation is succesfull, test runner is also deployed into **Heracles/Service/Packages/NUnitConsoleRunner{version}** folder, so runtests.bat is supposed to be able to run and expecting it to be there.
3. If test runner is installed manually, runtests.bat needs to be changed to search for it at the correct place

# 2. How to setup automated test
## 2.1. UI test setup
### 2.1.1. Selenium
1. <a id="driversId">Get and put Selenium browser drivers from WEB</a>
They can be found at 
[GitHub](https://github.com/lmc-eu/steward/wiki/Selenium-server-&-browser-drivers)
and
[SeleniumHQ](https://www.seleniumhq.org/download/)

2. Put the drivers onto search path, or in the same folder as the executable

3. Select which browsers should be used for UI testing in the app configuration file. [See Example](#exampleId)

### 2.1.2. Integration tests setup
1. Set the client page path (**WebSiteRoot**) in the test app configuration file. [See Example](#exampleId)

2. Set the MainService.exe path (and optionally the name) in the test app configuration file. (**TestedProcess** and **TestedProcessPath**) [See Example](#exampleId): 

3. Setup the enabled browsers. If multiple browsers enabled then the tests are executed on each of them. Remember to download and deploy the browser drivers [See](#driversId)
4. <a id="exampleId">Example configuration</a>

    1. How to edit the configuration file

        1. In Visual Studio before compilation the file can be found in the IntegrationTests project in the solution browser as app.config. This file is copied during compilation to the bin/debug folder.

        2. In any text editor please find the IntegrationTests.config file in the **heracles\Service\Tests\IntegrationTests\bin\Debug** folder. There your changes will affect the automated tests. 


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