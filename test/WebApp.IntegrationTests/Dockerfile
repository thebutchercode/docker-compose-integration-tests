FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR "/src"
COPY test/WebApp.IntegrationTests test/WebApp.IntegrationTests/
COPY . .

FROM build AS test
RUN dotnet test test/WebApp.IntegrationTests --logger:junit

FROM scratch AS export-test-result
COPY --from=test /src/test/test/WebApp.IntegrationTests/TestResults/TestResults.xml ./