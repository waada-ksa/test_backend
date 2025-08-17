FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["backend.API/backend.API.csproj", "backend.API/"]
COPY ["backend.Application/backend.Application.csproj", "backend.Application/"]
COPY ["backend.Core/backend.Core.csproj", "backend.Core/"]
COPY ["backend.Infrastructure/backend.Infrastructure.csproj", "backend.Infrastructure/"]
RUN dotnet restore "backend.API/backend.API.csproj"
COPY . .
WORKDIR "/src/backend.API"
RUN dotnet build "backend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend.API.dll"]
