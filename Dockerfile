# ---------- BUILD ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar solo el proyecto web
COPY MonoStudio.Web/MonoStudio.Web.csproj MonoStudio.Web/
RUN dotnet restore MonoStudio.Web/MonoStudio.Web.csproj

# Copiar todo el código
COPY . .

# Publicar
WORKDIR /app/MonoStudio.Web
RUN dotnet publish -c Release -o out

# ---------- RUNTIME ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/MonoStudio.Web/out .

# Render usa el puerto 10000
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "MonoStudio.Web.dll"]
