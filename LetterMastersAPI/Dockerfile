FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY LetterMastersAPI/LetterMastersAPI.csproj LetterMastersAPI/
RUN dotnet restore LetterMastersAPI/LetterMastersAPI.csproj
COPY . .
WORKDIR /src/LetterMastersAPI
RUN dotnet build LetterMastersAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish LetterMastersAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LetterMastersAPI.dll"]
