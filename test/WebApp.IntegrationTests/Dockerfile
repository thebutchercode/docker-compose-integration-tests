FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR "/app"
COPY . .
RUN dotnet restore
#ENTRYPOINT ["dotnet", "test"]
#ENTRYPOINT ["dotnet", "test", "test/WebApp.IntegrationTests --logger:junit"] 

ENTRYPOINT ["dotnet", "test", "--logger:junit"]


#FROM build AS test
#RUN dotnet test test/WebApp.IntegrationTests --logger:junit
#
#FROM scratch AS export-test-result
#COPY --from=test /src/test/test/WebApp.IntegrationTests/TestResults/TestResults.xml ./