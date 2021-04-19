# Build
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine as build

WORKDIR /app

RUN apk add --update nodejs npm netcat-openbsd

COPY paket.dependencies ./paket.dependencies
COPY .config/. .config/.
COPY .paket/. .paket/.
COPY paket.lock paket.lock

COPY server/. server/.
COPY shared/. shared/.
COPY client/. client/.

RUN dotnet tool restore
RUN dotnet paket install
WORKDIR /app/client
RUN npm ci
RUN npm run build
WORKDIR /app/server
RUN dotnet publish -c release -o out

# Run
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine
WORKDIR /app/server
COPY --from=build /app/server/out .
RUN mkdir dist
COPY --from=build /app/client/dist dist/.
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
CMD dotnet server.dll