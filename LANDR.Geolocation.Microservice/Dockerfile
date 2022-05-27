#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LANDR.Geolocation.Microservice/LANDR.Geolocation.Microservice.csproj", "LANDR.Geolocation.Microservice/"]
RUN dotnet restore "LANDR.Geolocation.Microservice/LANDR.Geolocation.Microservice.csproj"
COPY . .
WORKDIR "/src/LANDR.Geolocation.Microservice"
RUN dotnet build "LANDR.Geolocation.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LANDR.Geolocation.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LANDR.Geolocation.Microservice.dll"]
ENV ConfigurationMicroservice:OnlineService=true
ENV MaxMind:AccountId="723864"
ENV MaxMind:LicenseKey="gmOzUxIZsddwrWuM"