FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2.100-preview3-sdk AS build
WORKDIR /src
COPY ["Services/LoremIpsum-Service/LoremIpsumService.csproj", "Services/LoremIpsum-Service/"]
RUN dotnet restore "Services/LoremIpsum-Service/LoremIpsumService.csproj"
COPY . .
WORKDIR "/src/Services/LoremIpsum-Service"
RUN dotnet build "LoremIpsumService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LoremIpsumService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoremIpsumService.dll"]