FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TGBot/TGBot.csproj", "TGBot/"]
RUN dotnet restore "TGBot/TGBot.csproj"
COPY . .
WORKDIR "/src/TGBot"
RUN dotnet build "TGBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TGBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TGBot.dll"]