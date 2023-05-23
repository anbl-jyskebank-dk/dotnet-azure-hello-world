FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
COPY --from=build-env /app/out .
ARG CONN_STRING
ENV APPLICATIONINSIGHTS_CONNECTION_STRING=$CONN_STRING
ENTRYPOINT ["./dotnet-azure-hello-world"]
