FROM microsoft/dotnet:2.1.300-sdk AS build
WORKDIR /app

# Copy everything else and build
COPY WebApplication3/* ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "./WebApplication3.dll"]