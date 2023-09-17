0 Create first project as C# NUnit project
1 Infra is folder
2 When add project! to infra do not forget to select path folder infra
3 in project create folder per page and put page class into the folder (this way allows to have same class names as same pages in different projects)
4 To share POM class - right click on "EmptySeleniumCSharp" main project and select "add" project references and select added project of POM from the list
5 Go to the "Tools" than "NuGet package manager" "Manage Nuget Packages" find and install - selenium, dot net selenium extras, appium 


add to cproj file in case you cant read App.config properties
<Target Name="CopyAppConfig" AfterTargets="Build" DependsOnTargets="Build">
    <CreateItem Include="$(OutputPath)$(AssemblyName).dll.config">
        <Output TaskParameter="Include" ItemName="FilesToCopy"/>
    </CreateItem>
    <Copy SourceFiles="@(FilesToCopy)" DestinationFiles="$(OutputPath)testhost.dll.config" />
  </Target>

  appium last version does not working AppiumOptions options = new AppiumOptions(); 
  need to return to 3.141 selenium 

  Page object also does not working - depricated

  To run from cmd download and install nunitlite-runner.exe
  https://github.com/nunit/nunit/releases/tag/v3.13.3



  C:\NunitConsole>nunit3-console.exe "D:\Dev\CSharp\EmptySeleniumCSharp\EmptySeleniumCSharp\bin\Debug\net6.0\EmptySeleniumCSharp.dll" --where "cat == TestFirst" 

  Test1 is defined test category in test

  Also you can run it like this - runs better
  dotnet test "D:\Dev\CSharp\EmptySeleniumCSharp\EmptySeleniumCSharp\bin\Debug\net6.0\EmptySeleniumCSharp.dll" --filter TestCategory="TestFirst"

  