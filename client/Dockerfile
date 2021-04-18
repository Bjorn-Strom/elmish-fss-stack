# Build
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine as build

WORKDIR /app

RUN apk add --update nodejs npm netcat-openbsd

COPY client/package.json client/package.json
COPY client/package-lock.json client/package-lock.json
COPY paket.dependencies ./paket.dependencies
COPY .config/. .config/.
COPY .paket/. .paket/.
COPY paket.lock paket.lock

COPY client/. client/.
COPY shared/. shared/.

RUN dotnet tool restore
RUN dotnet paket install
WORKDIR /app/client
RUN npm i
RUN npm run build

# Run
FROM nginx:stable-alpine
COPY --from=build /app/client/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]