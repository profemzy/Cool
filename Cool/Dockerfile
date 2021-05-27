#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Cool/Cool.csproj", "Cool/"]
RUN dotnet restore "Cool/Cool.csproj"
COPY . .
WORKDIR "/src/Cool"
RUN dotnet build "Cool.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cool.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cool.dll"]
