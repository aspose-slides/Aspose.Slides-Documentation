FROM mcr.microsoft.com/dotnet/sdk:10.0.403-noble AS build
WORKDIR /src
COPY Example.csproj global.json ./
RUN dotnet restore Example.csproj
COPY *.cs example-manifest.json ./
COPY Fonts ./Fonts
RUN dotnet publish Example.csproj --no-restore --configuration Release --output /app /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime:10.0.14-noble
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core libicu74 \
    && rm -rf /var/lib/apt/lists/* \
    && mkdir -p /output && chown "$APP_UID:$APP_UID" /output
WORKDIR /app
COPY --from=build /app ./
USER $APP_UID
ENTRYPOINT ["dotnet", "Example.dll"]
CMD ["--input", "/input/source.pptx", "--output", "/output"]
