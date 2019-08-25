# How to setup test
## UI test setup
### Selenium
1. <a id="driversId">Get and put Selenium browser drivers from WEB</a>

[GitHub](https://github.com/lmc-eu/steward/wiki/Selenium-server-&-browser-drivers)

[SeleniumHQ](https://www.seleniumhq.org/download/)

2. Put the drivers onto search path, or in the same folder as the executable
### Client page folder
1. Set the client page path in the test app configuration file [See Example](#exampleId)

1. Set the MainService.exe path (and optionally the name) in the test app configuration file [See Example](#exampleId): 

2. Setup the enabled browsers. If multiple browsers enabled then the tests are executed on each of them. Remember to download and deploy the browser drivers [See](#driversId)
2. <a id="exampleId">Example</a>
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