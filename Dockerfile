# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ARG FOLDER=/app

COPY . /app

RUN dotnet restore

RUN dotnet publish component-asp.csproj -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

ARG FOLDER=/app

WORKDIR ${FOLDER}

COPY --from=build ${FOLDER}/out ./

EXPOSE 5103

ENV ASPNETCORE_URLS=http://+:5103

ENTRYPOINT ["dotnet", "component-asp.dll"]
