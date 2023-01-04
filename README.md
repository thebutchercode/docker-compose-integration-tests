# ASP.NET Core integration testing with docker-compose
This project demonstrates Integration tests written in NET can be run using Docker containers.

# Prerequisites
 * Install Docker on Windows Pro/Enterprise: https://docs.docker.com/engine/installation/
 * Virtualization needs to be enabled at the BIOS level;
 * Hyper-V needs to be enabled as well, check here how to do it from the command line: https://stackoverflow.com/questions/30496116/how-to-disable-hyper-v-in-command-line#answer-35812945


# The sample application
This solution is made of four projects:
 * An ASP.NET Core Web API sample application containing just a WeatherForecastController;
 * An ASP.NET library project. 
 * An integration test project that's going to run when executing the `run-integration-tests.bat` from the command line;
 * A unit test project that won't be used by this example.

 # The `run-integration-tests.bat` file
 This script will launch the `docker-compose` command to build and run the API application and the integration test projects in a containers. As described by the `docker-compose.yml` file, here's the hierearchy of containers:
 * The integration test project
   * depends upon the webapi container
     * which depends upon a Sql Server for Linux container

  ![Container hierarchy diagram](diagram.png)

 When first run, the `run-integration-tests.bat` script will cause the download of the `microsoft/aspnetcore` and `microsoft/mssql-server-linux` images (around 2GB total). Be patient while they're being downloaded.

 Integration tests will run as soon as the two containers have been created and a green message will appear in the output.

 ![Tests passed](output.png)

 Containers are destroyed and the end and recreated at each execution of the script, so that test results can be deterministic.