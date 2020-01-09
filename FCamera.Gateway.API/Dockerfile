FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["FCamera.Gateway.API/FCamera.Gateway.API.csproj", "FCamera.Gateway.API/"]
RUN dotnet restore "FCamera.Gateway.API/FCamera.Gateway.API.csproj"
COPY . .
WORKDIR "/src/FCamera.Gateway.API"
RUN dotnet build "FCamera.Gateway.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FCamera.Gateway.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FCamera.Gateway.API.dll"]