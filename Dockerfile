# =============================
#   BUILD STAGE
# =============================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy everything and restore dependencies
COPY . .
RUN dotnet restore "BYUClinicCareApp/BYUClinicCareApp.csproj"

# Build and publish in Release mode
RUN dotnet publish "BYUClinicCareApp/BYUClinicCareApp.csproj" -c Release -o /app/publish

# =============================
#   RUNTIME STAGE
# =============================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:10000
ENV ASPNETCORE_ENVIRONMENT=Production

# Run the app
ENTRYPOINT ["dotnet", "BYUClinicCareApp.dll"]
