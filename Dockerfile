# ---------- BUILD ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar csproj y restaurar dependencias
COPY StudyFlow/StudyFlow.csproj StudyFlow/
RUN dotnet restore StudyFlow/StudyFlow.csproj

# Copiar todo el código
COPY . .

# Publicar
WORKDIR /app/StudyFlow
RUN dotnet publish -c Release -o out

# ---------- RUNTIME ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/StudyFlow/out .

ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "StudyFlow.dll"]
