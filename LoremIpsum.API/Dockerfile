FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:sdk AS build
WORKDIR /src
COPY LoremIpsum.API/LoremIpsum.API.csproj LoremIpsum.API/
RUN apt-get update && apt-get install -y libcurl3
RUN dotnet restore LoremIpsum.API/LoremIpsum.API.csproj
COPY . .
WORKDIR /src/LoremIpsum.API
RUN dotnet build "LoremIpsum.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LoremIpsum.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoremIpsum.API.dll"]