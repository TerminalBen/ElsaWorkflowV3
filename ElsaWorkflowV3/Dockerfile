#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ElsaWorkflowV3/ElsaWorkflowV3.csproj", "ElsaWorkflowV3/"]
RUN dotnet restore "ElsaWorkflowV3/ElsaWorkflowV3.csproj"
COPY . .
WORKDIR "/src/ElsaWorkflowV3"
RUN dotnet build "ElsaWorkflowV3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElsaWorkflowV3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElsaWorkflowV3.dll"]