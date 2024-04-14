#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 4433

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Devops_deploy/Devops_deploy.csproj", "Devops_deploy/"]
RUN dotnet restore "Devops_deploy/Devops_deploy.csproj"
COPY . .
WORKDIR "/src/Devops_deploy"
RUN dotnet build "Devops_deploy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Devops_deploy.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Devops_deploy.dll"]