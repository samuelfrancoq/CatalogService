# Stage 1: Build and compile the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the solution file
COPY CatalogService.sln ./

# Copy all .csproj files preserving the folder structure automatically
COPY CatalogService.Api/*.csproj ./CatalogService.Api/
COPY CatalogService.Api.IntegrationTests/*.csproj ./CatalogService.Api.IntegrationTests/
COPY CatalogService.Application/*.csproj ./CatalogService.Application/
COPY CatalogService.Infrastructure/*.csproj ./CatalogService.Infrastructure/
COPY CatalogService.Domain/*.csproj ./CatalogService.Domain/
COPY CatalogService.Application.UnitTests/*.csproj ./CatalogService.Application.UnitTests/

# Restore dependencies
RUN dotnet restore

# Copy the entire source code and publish the release binaries
COPY . ./
RUN dotnet publish CatalogService.Api/CatalogService.Api.csproj -c Release -o /app/out

# Stage 2: Minimal runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .

USER app
EXPOSE 8080

ENTRYPOINT ["dotnet", "CatalogService.Api.dll"]