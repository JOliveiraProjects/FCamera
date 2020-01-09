FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["FCamera.Teste.API/FCamera.Teste.API.csproj", "FCamera.Teste.API/"]
RUN dotnet restore "FCamera.Teste.API/FCamera.Teste.API.csproj"
COPY . .
WORKDIR "/src/FCamera.Teste.API"
RUN dotnet build "FCamera.Teste.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FCamera.Teste.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FCamera.Teste.API.dll"]