rem see https://github.com/nunit/docs/wiki/Console-Command-Line for command line parameters of nunit3-console
echo test results will be detailed in TestResult.xml
packages\NUnit.ConsoleRunner.3.10.0\tools\nunit3-console.exe Tests\ControllerTest\bin\Debug\controllertest.dll Tests\IntegrationTests\bin\Debug\IntegrationTest.dll -wait




