#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NotesApp.WebApi/NotesApp.WebApi.csproj", "NotesApp.WebApi/"]
RUN dotnet restore "NotesApp.WebApi/NotesApp.WebApi.csproj"
COPY . .
WORKDIR "/src/NotesApp.WebApi"
RUN dotnet build "NotesApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotesApp.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotesApp.WebApi.dll"]