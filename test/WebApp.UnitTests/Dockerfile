#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR "/src"
#COPY test/WebApp.UnitTests test/WebApp.UnitTests/
#COPY . .
#
#FROM build AS test
#RUN dotnet test test/WebApp.UnitTests --logger:junit
#
#FROM scratch AS export-test-result
#COPY --from=test /src/test/WebApp.UnitTests/TestResults/TestResults.xml ./

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR "/app"
COPY test/WebApp.UnitTests test/WebApp.UnitTests/
COPY . .
RUN dotnet restore

FROM build AS test
#RUN dotnet test test/WebApp.UnitTests --logger:junit

ENTRYPOINT ["dotnet", "test", "--logger:junit"]
#ENTRYPOINT ["dotnet", "test", "test/WebApp.UnitTests --logger:junit"]

#FROM scratch AS export-test-result
#COPY --from=test /src/test/WebApp.UnitTests/TestResults/TestResults.xml ./
