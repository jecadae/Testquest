FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestQuest/TestQuest.csproj", "TestQuest/"]
RUN dotnet restore "TestQuest/TestQuest.csproj"
COPY . .
WORKDIR "/src/TestQuest"
RUN dotnet build "TestQuest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestQuest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestQuest.dll"]
