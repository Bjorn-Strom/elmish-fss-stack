# Build
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine as build

WORKDIR /app

COPY paket.dependencies ./paket.dependencies
COPY .config/. .config/.
COPY .paket/. .paket/.
COPY paket.lock paket.lock

COPY server/. server/.
COPY shared/. shared/.

RUN dotnet tool restore
RUN dotnet paket install
WORKDIR /app/server
RUN dotnet publish -c release -o out

# Run
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine
WORKDIR /app/server
COPY --from=build /app/server/out .
CMD dotnet server.dll