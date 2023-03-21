FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EfCorePerformanceTest/EfCorePerformanceTest.csproj", "EfCorePerformanceTest/"]
RUN dotnet restore "EfCorePerformanceTest/EfCorePerformanceTest.csproj"
COPY . .
WORKDIR "/src/EfCorePerformanceTest"
RUN dotnet build "EfCorePerformanceTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EfCorePerformanceTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EfCorePerformanceTest.dll"]
