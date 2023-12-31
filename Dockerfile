﻿FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LAB_6to12.csproj", "./"]
RUN dotnet restore "LAB_6to12.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "LAB_6to12.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LAB_6to12.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LAB_6to12.dll"]
