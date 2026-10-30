FROM mcr.microsoft.com/dotnet/sdk:8.0.427-noble AS build
WORKDIR /src
COPY Example.csproj global.json packages.lock.json ./
RUN dotnet restore Example.csproj --locked-mode
COPY Program.cs ./
RUN dotnet publish Example.csproj --no-restore --configuration Release --output /app /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime:8.0.33-noble
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app ./
USER $APP_UID
ENTRYPOINT ["dotnet", "Example.dll"]
