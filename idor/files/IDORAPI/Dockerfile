FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 8080
RUN mkdir -p /home/files && echo "Root credits: root; v3rYssTr00n9ANdUnable_TOh4ck" > /home/files/1.txt
ENTRYPOINT ["dotnet", "IDORAPI.dll"]
