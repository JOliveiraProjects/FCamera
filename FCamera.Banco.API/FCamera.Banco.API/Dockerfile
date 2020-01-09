FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["FCamera.Banco.API/FCamera.Banco.API.csproj", "FCamera.Banco.API/"]
COPY ["FCamera.Banco.Repository/FCamera.Banco.Repository.csproj", "FCamera.Banco.Repository/"]
COPY ["FCamera.Banco.Domain/FCamera.Banco.Domain.csproj", "FCamera.Banco.Domain/"]
RUN dotnet restore "FCamera.Banco.API/FCamera.Banco.API.csproj"
COPY . .
WORKDIR "/src/FCamera.Banco.API"
RUN dotnet build "FCamera.Banco.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FCamera.Banco.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FCamera.Banco.API.dll"]